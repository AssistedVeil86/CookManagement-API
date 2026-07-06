using System.Security.Claims;
using CookManagement.VSA.Infrastructure.Data;
using CookManagement.VSA.Infrastructure.Extensions;
using CookManagement.VSA.Infrastructure.TimeZones;
using CookManagement.VSA.Shared.Entities;
using CookManagement.VSA.Shared.Enums;
using CookManagement.VSA.Shared.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CookManagement.VSA.Features.Movements.RegisterMovements;

public static class RegisterMovementEndpoint
{
    public static RouteGroupBuilder MapRegisterMovementEndpoint(this RouteGroupBuilder route)
    {
        route.MapPut("register-movement", Handler)
            .Produces<MovementResponse>()
            .Produces(StatusCodes.Status404NotFound);

        return route;
    }

    private static async Task<IResult> Handler(
        MovementRequest request, RegisterMovementHandler handler, ClaimsPrincipal user)
    {
        var userId = user.GetUserId();
        var userRole = user.GetUserRole();

        var result = await handler.HandleAsync(userId, userRole, request);
        return Results.Ok(result);
    }
}

internal sealed class RegisterMovementHandler(
    CookDbContext context,
    ILogger<RegisterMovementHandler> logger,
    TimeZoneService timeZoneService)
{
    public async Task<MovementResponse> HandleAsync(int userId, string userRole, MovementRequest request)
    {
        logger.LogInformation("El usuario con ID {userId} quiere registrar un " +
                               "movimiento: {movement}, con cantidad: {count}"
            , userId, request.MovementType, request.MovementCount);

        var inventoryType = userRole == nameof(UserRole.Cocina)
            ? InventoryType.Cocina
            : InventoryType.Bar;

        var (startOfDayUtc, endOfDayUtc) = timeZoneService.GetTodayBoundariesInUtc(request.TimeZoneId);

        var userRecord = await context.UserRecords
            .Where(r => r.UserId == userId
                    && r.CreatedAt >= startOfDayUtc
                    && r.CreatedAt < endOfDayUtc
                    && r.InventoryType == inventoryType
                    && r.ProductCode == request.ProductCode)
            .FirstOrDefaultAsync()
                ?? throw new CustomNotFoundException("No existe registro para este producto");

        var movementCount = await RegisterMovementType(userRecord, request, inventoryType);
        var utcNow = DateTime.UtcNow;

        userRecord.UpdatedAt = utcNow;

        await context.SaveChangesAsync();

        logger.LogInformation("El usuario con ID {userId} ha registrado exitosamente un " +
                               "movimiento de tipo: {movement}, con cantidad: {count}"
            , userId, request.MovementType, movementCount);

        return MappingExtensions.MapToMovementResponse(userRecord.ProductCode, movementCount, request.MovementType);
    }

    private async Task<Double> RegisterMovementType(UserRecord record, MovementRequest request, InventoryType inventoryType)
    {
        return request.MovementType switch
        {
            MovementType.Courtesy => record.Courtesy += request.MovementCount,
            MovementType.Damaged => record.Damaged += request.MovementCount,
            MovementType.Entry => await UpdateStockForEntry(record, request, inventoryType),
            MovementType.Remains => record.Remains += request.MovementCount,
            _ => throw new CustomInvalidOperationException("Tipo de Movimiento Inválido")
        };
    }

    private async Task<Double> UpdateStockForEntry(UserRecord record, MovementRequest request, InventoryType inventoryType)
    {
        BaseInventory? inventoryItem = null;

        if (inventoryType == InventoryType.Cocina)
        {
            inventoryItem = await context.KitchenInventory
                .FirstOrDefaultAsync(i => i.Code == request.ProductCode);
        }
        else
        {
            inventoryItem = await context.BarInventory
                .FirstOrDefaultAsync(i => i.Code == request.ProductCode);
        }

        if (inventoryItem is null)
        {
            throw new CustomNotFoundException($"El Producto con código {request.ProductCode} no existe en " +
                $"el Inventario de {inventoryType}");
        }

        var entries = record.Entries + request.MovementCount;
        inventoryItem.CurrentStock += entries;
        record.Entries = (int)entries;

        return entries;
    }
}

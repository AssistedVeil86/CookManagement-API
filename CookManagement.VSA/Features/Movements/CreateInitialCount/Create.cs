using System.Security.Claims;
using CookManagement.VSA.Features.Movements.Shared;
using CookManagement.VSA.Infrastructure.Data;
using CookManagement.VSA.Infrastructure.Extensions;
using CookManagement.VSA.Infrastructure.TimeZones;
using CookManagement.VSA.Domain.Entities;
using CookManagement.VSA.Domain.Enums;
using CookManagement.VSA.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CookManagement.VSA.Features.Movements.CreateInitialCount;

public static class CreateInitialCountEndpoint
{
    public static RouteGroupBuilder MapCreateInitialCountEndpoint(this RouteGroupBuilder route)
    {
        route.MapPost("initial-count", Handler)
            .Produces<InitialCountResponse>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status409Conflict)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest);

        return route;
    }

    private static async Task<IResult> Handler(
        CountRequest request, CreateInitialCountHandler handler,
        ClaimsPrincipal user, InventoryType? inventoryType)
    {
        var userId = user.GetUserId();
        var userRole = user.GetUserRole();

        var result = await handler.HandleAsync(userId, userRole, request, inventoryType);
        return Results.Created(nameof(MapCreateInitialCountEndpoint), result);
    }
}

internal sealed class CreateInitialCountHandler(
    CookDbContext context,
    ILogger<CreateInitialCountHandler> logger,
    TimeZoneService timeZoneService)
{
    public async Task<InitialCountResponse> HandleAsync(
        int userId, string userRole, CountRequest request, InventoryType? inventoryType)
    {
        if (request.Count < 0)
            throw new CustomInvalidOperationException("El Conteo Inicial no puede ser negativo");

        var (startOfDayUtc, endOfDayUtc) = timeZoneService.GetTodayBoundariesInUtc(request.TimeZoneId);

        var todayRecord = await context.UserRecords
            .Where(r => r.UserId == userId
                    && r.CreatedAt >= startOfDayUtc
                    && r.CreatedAt < endOfDayUtc
                    && r.ProductCode == request.ProductCode)
            .AnyAsync();

        if (todayRecord)
            throw new CustomConflictException("El Inventario Inicial para ese Producto ya ha sido creado");

        var user = await context.Users.FindAsync(userId)
            ?? throw new CustomNotFoundException("El Usuario no existe");

        var resolvedInventoryType = inventoryType ??
            (userRole == nameof(UserRole.Cocina) ? InventoryType.Cocina : InventoryType.Bar);

        var inventoryProduct = await
            GetInventoryProductNameByType(resolvedInventoryType, request.ProductCode);

        if (request.Count > inventoryProduct.CurrentStock || request.Count < inventoryProduct.CurrentStock)
            throw new CustomInvalidOperationException("El Conteo Inicial es Inválido");

        logger.LogInformation("El usuario {userName} con ID {userId} quiere registrar el " +
                               "inventario inicial para el producto con codigo {productCode}",
            user.Name, user.Id, request.ProductCode);

        var utcNow = DateTime.UtcNow;

        var userRecord = new UserRecord()
        {
            UserId = user.Id,
            User = user,
            ProductCode = request.ProductCode,
            ProductName = inventoryProduct.Product,
            InitialInventory = request.Count,
            FinalInventory = 0,
            Difference = 0,
            DailyMove = 0,
            Entries = 0,
            Courtesy = 0,
            Damaged = 0,
            Remains = 0,
            InventoryType = resolvedInventoryType,
            CreatedAt = utcNow,
            UpdatedAt = utcNow,
        };

        context.UserRecords.Add(userRecord);
        await context.SaveChangesAsync();

        logger.LogInformation("El usuario {userName} con ID {userID} ha registrado existosamente el " +
                               "inventario inicial para el producto con codigo {productCode}",
            user.Name, request.ProductCode, user.Id);

        return userRecord.MapToInitialCount();
    }

    private async Task<BaseInventory> GetInventoryProductNameByType(InventoryType inventoryType, string code)
    {
        return inventoryType switch
        {
            InventoryType.Cocina => await context.KitchenInventory
                .Where(p => p.Code == code)
                .Select(p => new BaseInventory
                {
                    Product = p.Product,
                    CurrentStock = p.CurrentStock
                })
                .FirstOrDefaultAsync()
                ?? throw new CustomNotFoundException("El producto no existe en el inventario de cocina"),

            InventoryType.Bar => await context.BarInventory
                .Where(p => p.Code == code)
                .Select(p => new BaseInventory
                {
                    Product = p.Product,
                    CurrentStock = p.CurrentStock
                })
                .FirstOrDefaultAsync()
                ?? throw new CustomNotFoundException("El producto no existe en el inventario de bar"),

            _ => throw new CustomInvalidOperationException("Tipo de inventario no válido"),
        };
    }
}

using System.Security.Claims;
using CookManagement.VSA.Domain.Entities;
using CookManagement.VSA.Domain.Enums;
using CookManagement.VSA.Domain.Exceptions;
using CookManagement.VSA.Features.Movements.Shared;
using CookManagement.VSA.Infrastructure.Data;
using CookManagement.VSA.Infrastructure.Extensions;
using CookManagement.VSA.Infrastructure.TimeZones;
using Microsoft.EntityFrameworkCore;

namespace CookManagement.VSA.Features.Movements.UpdateFinalCount;

public static class UpdateFinalEndpoint
{
    public static RouteGroupBuilder MapUpdateFinalCountEndpoint(this RouteGroupBuilder route)
    {
        route.MapPut("final-count", Handler)
            .Produces<FinalCountResponse>()
            .Produces(StatusCodes.Status409Conflict)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest);

        return route;
    }

    private static async Task<IResult> Handler(
        CountRequest request, ClaimsPrincipal user, UpdateFinalCountHandler handler)
    {
        var userId = user.GetUserId();
        var userRole = user.GetUserRole();

        var result = await handler.HandleAsync(userId, userRole, request);
        return Results.Ok(result);
    }
}

internal sealed class UpdateFinalCountHandler(
    CookDbContext context,
    ILogger<UpdateFinalCountHandler> logger,
    TimeZoneService timeZoneService)
{
    public async Task<FinalCountResponse> HandleAsync(int userId, string userRole, CountRequest request)
    {
        logger.LogInformation("El usuario con ID {userId} quiere registrar el inventario final " +
                               "para el producto con código {productCode}, con cantidad: {count}"
            , userId, request.ProductCode, request.Count);

        if (request.Count < 0)
            throw new CustomConflictException("El conteo final no puede ser negativo");

        var (startOfDayUtc, endOfDayUtc) = timeZoneService.GetTodayBoundariesInUtc(request.TimeZoneId);

        var inventoryType = userRole == nameof(UserRole.Cocina) ? InventoryType.Cocina : InventoryType.Bar;

        var userRecord = await context.UserRecords
            .Where(r => r.UserId == userId
                    && r.CreatedAt >= startOfDayUtc
                    && r.CreatedAt < endOfDayUtc
                    && r.InventoryType == inventoryType
                    && r.ProductCode == request.ProductCode)
            .FirstOrDefaultAsync()
            ?? throw new CustomNotFoundException("No existe registro para este producto");

        if (userRecord.FinalInventory > 0)
            throw new CustomInvalidOperationException("El Inventario Final para ese product ya ha sido creado hoy");

        var utcNow = DateTime.UtcNow;
        var dailyMove = CalculateDailyMovement(userRecord);

        userRecord.FinalInventory = request.Count;
        userRecord.Difference = CalculateDifference(userRecord, dailyMove);
        userRecord.DailyMove = dailyMove;
        userRecord.UpdatedAt = utcNow;

        await UpdateInventoryProductStock(inventoryType, request.ProductCode, request.Count);

        await context.SaveChangesAsync();

        logger.LogInformation("El usuario con ID {userId} ha registrado exitosamente el inventario final " +
                               "para el producto con código {productCode}, con cantidad: {count}"
            , userId, request.ProductCode, request.Count);

        return userRecord.MapToFinalCount();
    }

    private Double CalculateDifference(UserRecord record, double dailyMove)
    {
        var sales = dailyMove - record.FinalInventory;

        return sales;
    }

    private Double CalculateDailyMovement(UserRecord record)
    {
        return record.InitialInventory + record.Entries - (record.Damaged + record.Courtesy + record.Remains);
    }

    private async Task UpdateInventoryProductStock(InventoryType inventoryType, string code, Double finalCount)
    {
        BaseInventory? inventoryItem = null;

        if (inventoryType == InventoryType.Cocina)
        {
            inventoryItem = await context.KitchenInventory.FirstOrDefaultAsync(i => i.Code == code);
        }
        else
        {
            inventoryItem = await context.BarInventory.FirstOrDefaultAsync(i => i.Code == code);
        }

        if (inventoryItem is null)
            throw new CustomNotFoundException($"El Producto con código {code} no existe en " +
                $"el Inventario de {inventoryType}");

        if (inventoryItem.CurrentStock < finalCount || inventoryItem.CurrentStock == 0)
            throw new CustomInvalidOperationException("El Conteo Final no puede ser mayor al Stock");

        inventoryItem.CurrentStock = finalCount;
    }
}

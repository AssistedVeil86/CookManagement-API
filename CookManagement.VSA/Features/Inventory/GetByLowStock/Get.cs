using System.Security.Claims;
using CookManagement.VSA.Infrastructure.Data;
using CookManagement.VSA.Infrastructure.Extensions;
using CookManagement.VSA.Shared.Enums;
using CookManagement.VSA.Shared.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CookManagement.VSA.Features.Inventory.GetByLowStock;

public static class GetByLowStockEndpoint
{
    public static RouteGroupBuilder MapGetByLowStockEndpoint(this RouteGroupBuilder route)
    {
        route.MapGet("low-stock", Handler)
            .Produces<List<LowStockInventoryResponse>>()
            .Produces(StatusCodes.Status404NotFound)
            .RequireAuthorization("AdminOnly");

        return route;
    }

    private static async Task<IResult> Handler(
        ClaimsPrincipal user, GetByLowStockHandler handler, InventoryType? inventoryType)
    {
        var userId = user.GetUserId();
        var userRole = user.GetUserRole();

        var result = await handler.HandleAsync(userId, userRole, inventoryType);
        return Results.Ok(result);
    }
}

internal sealed class GetByLowStockHandler(CookDbContext context)
{
    public async Task<List<LowStockInventoryResponse>> HandleAsync(
        int userId, string userRole, InventoryType? inventoryType)
    {
        var userExists = await context.Users.AnyAsync(u => u.Id == userId);
        if (!userExists)
            throw new CustomNotFoundException("El Usuario no existe");

        var requestedInventoryType = DetermineInventoryType(userRole, inventoryType);
        var inventory = await GetInventoryByType(requestedInventoryType);

        return inventory;
    }

    private InventoryType DetermineInventoryType(string userRole, InventoryType? requestedType)
    {
        return userRole switch
        {
            var role when role == nameof(UserRole.Admin) => requestedType ?? InventoryType.Cocina,
            var role when role == nameof(UserRole.Cocina) => InventoryType.Cocina,
            _ => InventoryType.Bar
        };
    }

    private async Task<List<LowStockInventoryResponse>> GetInventoryByType(InventoryType requestedType)
    {
        return requestedType == InventoryType.Cocina
            ? await GetKitchenInventory()
            : await GetBarInventory();
    }

    private async Task<List<LowStockInventoryResponse>> GetKitchenInventory()
    {
        return await context.KitchenInventory
            .Where(x => x.CurrentStock <= x.MinimumStock)
            .Select(x => new LowStockInventoryResponse
            {
                Code = x.Code,
                Product = x.Product,
                Category = x.Category,
                MeasurementUnit = x.MeasurementUnit,
                CurrentStock = x.CurrentStock,
                MinimumStock = x.MinimumStock
            })
            .ToListAsync();
    }

    private async Task<List<LowStockInventoryResponse>> GetBarInventory()
    {
        return await context.BarInventory
            .Where(x => x.CurrentStock <= x.MinimumStock)
            .Select(x => new LowStockInventoryResponse
            {
                Code = x.Code,
                Product = x.Product,
                Category = x.Category,
                MeasurementUnit = null,
                CurrentStock = x.CurrentStock,
                MinimumStock = x.MinimumStock
            })
            .ToListAsync();
    }
}

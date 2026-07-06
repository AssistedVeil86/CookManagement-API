using System.Security.Claims;
using CookManagement.VSA.Domain.Enums;
using CookManagement.VSA.Domain.Exceptions;
using CookManagement.VSA.Infrastructure.Data;
using CookManagement.VSA.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace CookManagement.VSA.Features.Inventory.GetInventory;

public static class GetInventoryEndpoint
{
    public static RouteGroupBuilder MapGetInventoryEndpoint(this RouteGroupBuilder route)
    {
        route.MapGet("", Handler)
            .Produces<List<InventoryPaginatedResponse>>()
            .Produces(StatusCodes.Status404NotFound)
            .RequireAuthorization();

        return route;
    }

    private static async Task<IResult> Handler(
        ClaimsPrincipal user, GetInventoryHandler handler,
        InventoryType? inventoryType, string? category = "",
        int page = 1, int pageSize = 12)
    {
        var userId = user.GetUserId();
        var userRole = user.GetUserRole();

        var result =
        await handler.HandleAsync(userId, userRole, page, pageSize, inventoryType, category);

        return Results.Ok(result);
    }
}

internal sealed class GetInventoryHandler(CookDbContext context)
{
    public async Task<InventoryPaginatedResponse> HandleAsync(
        int userId, string userRole, int page, int pageSize, InventoryType? inventoryType, string? category)
    {
        var userExists = await context.Users.AnyAsync(u => u.Id == userId);
        if (!userExists)
            throw new CustomNotFoundException("El Usuario no existe");

        var requestedInventoryType = DetermineInventoryType(userRole, inventoryType);

        var inventory = await GetInventoryByType(requestedInventoryType, page, pageSize, category);
        var productCount = await CountInventoryByType(requestedInventoryType);

        return new InventoryPaginatedResponse()
        {
            Inventory = inventory,
            ProductCount = productCount,
        };
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

    private async Task<List<InventoryResponse>> GetInventoryByType(
        InventoryType requestedType, int page, int pageSize, string? category)
    {
        return requestedType == InventoryType.Cocina
            ? await GetKitchenInventory(page, pageSize, category)
            : await GetBarInventory(page, pageSize, category);
    }

    private async Task<int> CountInventoryByType(InventoryType requestedType)
    {
        return requestedType == InventoryType.Cocina
            ? await GetKitchenInventoryCount()
            : await GetBarInventoryCount();
    }

    private Task<List<InventoryResponse>> GetKitchenInventory(int page, int pageSize, string? category)
    {
        return context.KitchenInventory.AsNoTracking()
            .Where(x => x.Category.Contains(category))
            .OrderBy(x => x.Code)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(x => new InventoryResponse()
            {
                Code = x.Code,
                Product = x.Product,
                Category = x.Category,
                MeasurementUnit = x.MeasurementUnit,
                CurrentStock = x.CurrentStock,
                MinimumStock = x.MinimumStock
            }).ToListAsync();
    }

    private Task<List<InventoryResponse>> GetBarInventory(int page, int pageSize, string? category)
    {
        return context.BarInventory.AsNoTracking()
            .Where(x => x.Category.Contains(category))
            .OrderBy(x => x.Code)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(x => new InventoryResponse()
            {
                Code = x.Code,
                Product = x.Product,
                Category = x.Category,
                MeasurementUnit = null,
                CurrentStock = x.CurrentStock,
                MinimumStock = x.MinimumStock
            }).ToListAsync();
    }

    private Task<int> GetKitchenInventoryCount()
    {
        return context.KitchenInventory.CountAsync();
    }

    private Task<int> GetBarInventoryCount()
    {
        return context.BarInventory.CountAsync();
    }
}

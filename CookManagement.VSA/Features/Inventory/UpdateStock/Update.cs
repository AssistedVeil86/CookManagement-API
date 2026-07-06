using System.Security.Claims;
using CookManagement.VSA.Domain.Enums;
using CookManagement.VSA.Domain.Exceptions;
using CookManagement.VSA.Infrastructure.Data;
using CookManagement.VSA.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace CookManagement.VSA.Features.Inventory.UpdateStock;

public static class UpdateStockEndpoint
{
    public static RouteGroupBuilder MapUpdateStockEndpoint(this RouteGroupBuilder route)
    {
        route.MapPut("stock", Handler)
            .Produces<InventoryItemResponse>()
            .Produces(StatusCodes.Status404NotFound)
            .RequireAuthorization("AdminOnly");

        return route;
    }

    private static async Task<IResult> Handler(
        InventoryItemRequest request, UpdateStockHandler handler, ClaimsPrincipal user)
    {
        var userRole = user.GetUserRole();

        var result = await handler.HandleAsync(request, userRole);
        return Results.Ok(result);
    }
}

internal sealed class UpdateStockHandler(CookDbContext context, ILogger<UpdateStockHandler> logger)
{
    public async Task<InventoryItemResponse> HandleAsync(InventoryItemRequest request, string userRole)
    {
        var requestedType = DetermineInventoryType(userRole, request.InventoryType);

        var isKitchenRole = requestedType == InventoryType.Cocina;

        return isKitchenRole
            ? await UpdateKitchenProductStock(request.ProductName, request.NewStock)
            : await UpdateBarProductStock(request.ProductName, request.NewStock);
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

    private async Task<InventoryItemResponse> UpdateBarProductStock(string productName, double newStock)
    {
        logger.LogInformation("Se quiere actualizar el stock para el producto {productName}", productName);

        var product = await context.BarInventory
            .FirstOrDefaultAsync(b => b.Product == productName)
            ?? throw new CustomNotFoundException("Ese producto no existe en el inventario de Bar");

        product.CurrentStock = newStock;
        await context.SaveChangesAsync();

        logger.LogInformation("Se ha actualizado el stock para el producto {productName}: {productStock}",
            product.Product, product.CurrentStock);

        return MappingExtensions.MapToInvItemResponse(product.Code, product.Product, product.CurrentStock);
    }

    private async Task<InventoryItemResponse> UpdateKitchenProductStock(string productName, double newStock)
    {
        logger.LogInformation("Se quiere actualizar el stock para el producto {productName}", productName);

        var product = await context.KitchenInventory
            .FirstOrDefaultAsync(b => b.Product == productName)
            ?? throw new CustomNotFoundException("Ese producto no existe en el inventario de Cocina");

        product.CurrentStock = newStock;
        await context.SaveChangesAsync();

        logger.LogInformation("Se ha actualizado el stock para el producto {productName}: {productStock}",
            product.Product, product.CurrentStock);

        return MappingExtensions.MapToInvItemResponse(product.Code, product.Product, product.CurrentStock);
    }
}

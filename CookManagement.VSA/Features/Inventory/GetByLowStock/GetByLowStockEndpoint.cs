using System;
using System.Security.Claims;
using CookManagement.VSA.Infrastructure.Extensions;
using CookManagement.VSA.Shared.Enums;

namespace CookManagement.VSA.Features.Inventory.GetByLowStock;

public static class GetByLowStockEndpoint
{
    public static RouteGroupBuilder MapGetByLowStockEndpoint(this RouteGroupBuilder builder)
    {
        builder.MapGet("low-stock", async (GetByLowStockHandler handler,
            ClaimsPrincipal user, InventoryType? inventoryType) =>
        {
            var userId = user.GetUserId();
            var userRole = user.GetUserRole();

            var result = await handler.HandleAsync(userId, userRole, inventoryType);
            return Results.Ok(result);
        })
        .Produces<List<LowStockInventoryResponse>>()
        .Produces(StatusCodes.Status404NotFound)
        .RequireAuthorization("AdminOnly");

        return builder;
    }
}

using CookManagement.VSA.Infrastructure.Extensions;
using CookManagement.VSA.Shared.Enums;
using System.Security.Claims;

namespace CookManagement.VSA.Features.Inventory.GetInventory
{
    public static class GetInventoryEndpoint
    {
        public static RouteGroupBuilder MapGetInventoryEndpoint(this RouteGroupBuilder groupBuilder)
        {
            groupBuilder.MapGet("",
                    async (GetInventoryHandler handler, ClaimsPrincipal user, InventoryType? inventoryType, string? category,
                        int page = 1, int pageSize = 12) =>
                    {
                        var userId = user.GetUserId();
                        var userRole = user.GetUserRole();

                        var result =
                        await handler.HandleAsync(userId, userRole, page, pageSize, inventoryType, category);

                        return Results.Ok(result);
                    })
                .Produces<List<InventoryPaginatedResponse>>()
                .Produces(StatusCodes.Status404NotFound)
                .RequireAuthorization();

            return groupBuilder;
        }

    }
}

using System.Security.Claims;
using CookManagement.VSA.Infrastructure.Extensions;

namespace CookManagement.VSA.Features.Inventory.UpdateStock
{
    public static class UpdateStockEndpoint
    {
        public static RouteGroupBuilder MapUpdateStockEndpoint(this RouteGroupBuilder groupBuilder)
        {
            groupBuilder.MapPut("stock",
                async (UpdateStockHandler handler, ClaimsPrincipal user, InventoryItemRequest request) =>
                {
                    var userRole = user.GetUserRole();

                    var result = await handler.HandleAsync(request, userRole);
                    return Results.Ok(result);
                })
                .Produces<InventoryItemResponse>()
                .Produces(StatusCodes.Status404NotFound)
                .RequireAuthorization("AdminOnly");

            return groupBuilder;
        }
    }
}

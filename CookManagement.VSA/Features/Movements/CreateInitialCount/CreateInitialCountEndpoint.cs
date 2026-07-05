using System.Security.Claims;
using CookManagement.VSA.Infrastructure.Extensions;
using CookManagement.VSA.Shared.DTOs;
using CookManagement.VSA.Shared.Enums;

namespace CookManagement.VSA.Features.Movements.CreateInitialCount
{
    public static class CreateInitialCountEndpoint
    {
        public static RouteGroupBuilder MapCreateInitialCountEndpoint(this RouteGroupBuilder groupBuilder)
        {
            groupBuilder.MapPost("initial-count",
                async (CountRequest request, CreateInitialCountHandler handler,
                    ClaimsPrincipal user, InventoryType? inventoryType) =>
                {
                    var userId = user.GetUserId();
                    var userRole = user.GetUserRole();

                    var result = await handler.HandleAsync(userId, userRole, request, inventoryType);
                    return Results.Created(nameof(MapCreateInitialCountEndpoint), result);
                })
                .Produces<InitialCountResponse>(StatusCodes.Status201Created)
                .Produces(StatusCodes.Status409Conflict)
                .Produces(StatusCodes.Status404NotFound)
                .Produces(StatusCodes.Status400BadRequest);

            return groupBuilder;
        }

    }
}

using System.Security.Claims;
using CookManagement.VSA.Infrastructure.Extensions;
using CookManagement.VSA.Shared.DTOs;

namespace CookManagement.VSA.Features.Movements.UpdateFinalCount
{
    public static class UpdateFinalEndpoint
    {
        public static RouteGroupBuilder MapUpdateFinalCountEndpoint(this RouteGroupBuilder groupBuilder)
        {
            groupBuilder.MapPut("final-count",
                async (CountRequest request, ClaimsPrincipal user, UpdateFinalCountHandler handler) =>
                {
                    var userId = user.GetUserId();
                    var userRole = user.GetUserRole();

                    var result = await handler.HandleAsync(userId, userRole, request);
                    return Results.Ok(result);
                })
                .Produces<FinalCountResponse>()
                .Produces(StatusCodes.Status409Conflict)
                .Produces(StatusCodes.Status404NotFound)
                .Produces(StatusCodes.Status400BadRequest);

            return groupBuilder;
        }
    }
}

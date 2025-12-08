using CookManagement.VSA.Infrastructure.Extensions;
using System.Security.Claims;

namespace CookManagement.VSA.Features.Movements.RegisterMovements
{
    public static class RegisterMovementEndpoint
    {
        public static RouteGroupBuilder MapRegisterMovementEndpoint(this RouteGroupBuilder groupBuilder)
        {
            groupBuilder.MapPut("register-movement",
                async (MovementRequest request, RegisterMovementHandler handler, ClaimsPrincipal user) =>
                {
                    var userId = user.GetUserId();
                    var userRole = user.GetUserRole();

                    var result = await handler.HandleAsync(userId, userRole, request);
                    return Results.Ok(result);
                })
                .Produces<MovementResponse>()
                .Produces(StatusCodes.Status404NotFound);

            return groupBuilder;
        }

    }
}

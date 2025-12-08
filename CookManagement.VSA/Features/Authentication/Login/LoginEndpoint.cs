using CookManagement.VSA.Infrastructure.Extensions;

namespace CookManagement.VSA.Features.Authentication.Login
{
    public static class LoginEndpoint
    {
        public static RouteGroupBuilder MapLoginEndpoint(this RouteGroupBuilder groupBuilder)
        {
            groupBuilder.MapPost("login", async (LoginHandler handler, LoginRequest request) =>
            {
                var result = await handler.HandleAsync(request);
                return Results.Ok(result);
            })
                .Produces<TokenResponse>()
                .Produces(StatusCodes.Status400BadRequest)
                .Produces(StatusCodes.Status404NotFound)
                .WithRequestValidation<LoginRequest>();

            return groupBuilder;
        }
    }
}

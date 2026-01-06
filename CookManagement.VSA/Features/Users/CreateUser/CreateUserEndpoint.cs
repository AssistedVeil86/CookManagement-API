using CookManagement.VSA.Infrastructure.Extensions;
using CookManagement.VSA.Shared.DTOs;

namespace CookManagement.VSA.Features.Users.CreateUser;

public static class CreateUserEndpoint
{
    public static RouteGroupBuilder MapCreateUserEndpoint(this RouteGroupBuilder groupBuilder)
    {
        groupBuilder.MapPost("", async (CreateUserRequest request, CreateUserHandler handler) =>
        {
            var result = await handler.HandleAsync(request);
            return Results.Created($"/api/user/{result.UserId}", result);
        })
        .Produces<UserResponse>(StatusCodes.Status201Created)
        .WithRequestValidation<CreateUserRequest>();

        return groupBuilder;
    }
}

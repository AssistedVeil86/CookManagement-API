using CookManagement.VSA.Infrastructure.Extensions;
using CookManagement.VSA.Shared.DTOs;
namespace CookManagement.VSA.Features.Users.UpdateUser;

public static class UpdateUserEndpoint
{
    public static RouteGroupBuilder MapUpdateUserEndpoint(this RouteGroupBuilder groupBuilder)
    {
        groupBuilder.MapPut("{userId:int}", async (int userId, UserRequest request, UpdateUserHandler handler) =>
        {
            var result = await handler.HandleAsync(userId, request);
            return Results.Ok(result);
        })
        .Produces(StatusCodes.Status404NotFound)
        .Produces<UserResponse>(StatusCodes.Status200OK)
        .WithRequestValidation<UserRequest>();

        return groupBuilder;
    }
}

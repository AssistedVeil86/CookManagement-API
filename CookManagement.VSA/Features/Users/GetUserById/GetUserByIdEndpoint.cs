namespace CookManagement.VSA.Features.Users.GetUserById;

public static class GetUserByIdEndpoint
{
    public static RouteGroupBuilder MapGetUserByIdEndpoint(this RouteGroupBuilder groupBuilder)
    {
        groupBuilder.MapGet("/{userId:int}", async (int userId, GetUserByIdHandler handler) =>
        {
            var result = await handler.HandleAsync(userId);
            return Results.Ok(result);
        })
        .Produces<Shared.DTOs.UserResponse>(StatusCodes.Status200OK)
        .RequireAuthorization("SuperAdminOnly");

        return groupBuilder;
    }
}

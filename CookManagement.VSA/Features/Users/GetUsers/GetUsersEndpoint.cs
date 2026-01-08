namespace CookManagement.VSA.Features.Users.GetUsers;

public static class GetUsersEndpoint
{
    public static RouteGroupBuilder MapGetUsersEndpoint(this RouteGroupBuilder group)
    {
        group.MapGet("", async (GetUsersHandler handler) =>
        {
            var users = await handler.HandleAsync();
            return Results.Ok(users);
        })
        .Produces<List<Shared.DTOs.UserResponse>>(StatusCodes.Status200OK)
        .RequireAuthorization("SuperAdminOnly");

        return group;
    }
}

using CookManagement.VSA.Features.Users.Shared;
using CookManagement.VSA.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CookManagement.VSA.Features.Users.GetUsers;

public static class GetUsersEndpoint
{
    public static RouteGroupBuilder MapGetUsersEndpoint(this RouteGroupBuilder route)
    {
        route.MapGet("", Handler)
            .Produces<List<UserResponse>>(StatusCodes.Status200OK)
            .RequireAuthorization("SuperAdminOnly");

        return route;
    }

    private static async Task<IResult> Handler(GetUsersHandler handler)
    {
        var users = await handler.HandleAsync();
        return Results.Ok(users);
    }
}

internal sealed class GetUsersHandler(CookDbContext context)
{
    public async Task<List<UserResponse>> HandleAsync()
    {
        var users = context.Users
            .Where(u => u.Name != "AdminLinus");

        return await users.Select(u => new UserResponse
        {
            UserId = u.Id,
            Name = u.Name,
            UserRole = u.Role
        }).ToListAsync();
    }
}

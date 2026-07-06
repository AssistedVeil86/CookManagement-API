using CookManagement.VSA.Infrastructure.Data;
using CookManagement.VSA.Infrastructure.Extensions;
using CookManagement.VSA.Shared.DTOs;
using CookManagement.VSA.Shared.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CookManagement.VSA.Features.Users.GetUserById;

public static class GetUserByIdEndpoint
{
    public static RouteGroupBuilder MapGetUserByIdEndpoint(this RouteGroupBuilder route)
    {
        route.MapGet("/{userId:int}", Handler)
            .Produces<Shared.DTOs.UserResponse>(StatusCodes.Status200OK)
            .RequireAuthorization("SuperAdminOnly");

        return route;
    }

    private static async Task<IResult> Handler(int userId, GetUserByIdHandler handler)
    {
        var result = await handler.HandleAsync(userId);
        return Results.Ok(result);
    }
}

internal sealed class GetUserByIdHandler(CookDbContext context)
{
    public async Task<UserResponse> HandleAsync(int userId)
    {
        var user = await context.Users
            .Where(u => u.Id == userId).FirstOrDefaultAsync();

        if (user is null)
            throw new CustomNotFoundException("Ese usuario no encontrado");

        return user.MapToUserResponse();
    }
}

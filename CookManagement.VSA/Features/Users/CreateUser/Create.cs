using CookManagement.VSA.Infrastructure.Auth;
using CookManagement.VSA.Infrastructure.Data;
using CookManagement.VSA.Infrastructure.Extensions;
using CookManagement.VSA.Shared.DTOs;
using CookManagement.VSA.Shared.Entities;
using CookManagement.VSA.Shared.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CookManagement.VSA.Features.Users.CreateUser;

public static class CreateUserEndpoint
{
    public static RouteGroupBuilder MapCreateUserEndpoint(this RouteGroupBuilder route)
    {
        route.MapPost("", Handler)
            .Produces(StatusCodes.Status409Conflict)
            .Produces<UserResponse>(StatusCodes.Status201Created)
            .WithRequestValidation<UserRequest>()
            .RequireAuthorization("SuperAdminOnly");

        return route;
    }

    private static async Task<IResult> Handler(UserRequest request, CreateUserHandler handler)
    {
        var result = await handler.HandleAsync(request);
        return Results.Created($"/api/user/{result.UserId}", result);
    }
}

internal sealed class CreateUserHandler(CookDbContext context, PasswordHasher hasher)
{
    public async Task<UserResponse> HandleAsync(UserRequest request)
    {
        var userExists = await context.Users
            .Where(u => u.Name == request.Name).AnyAsync();

        if (userExists)
            throw new CustomConflictException("Ya existe un usuario con ese nombre.");

        var hashedPassword = hasher.HashPassword(request.Password);

        var user = new User
        {
            Name = request.Name,
            Password = hashedPassword,
            Role = request.Role
        };

        context.Users.Add(user);
        await context.SaveChangesAsync();

        return user.MapToUserResponse();
    }
}

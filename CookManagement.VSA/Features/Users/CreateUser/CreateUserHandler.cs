using CookManagement.VSA.Infrastructure.Auth;
using CookManagement.VSA.Infrastructure.Data;
using CookManagement.VSA.Infrastructure.Extensions;
using CookManagement.VSA.Shared.DTOs;
using CookManagement.VSA.Shared.Entities;
using CookManagement.VSA.Shared.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CookManagement.VSA.Features.Users.CreateUser;

public sealed class CreateUserHandler(CookDbContext context, PasswordHasher hasher)
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

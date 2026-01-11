using CookManagement.VSA.Infrastructure.Auth;
using CookManagement.VSA.Infrastructure.Data;
using CookManagement.VSA.Infrastructure.Extensions;
using CookManagement.VSA.Shared.DTOs;
using CookManagement.VSA.Shared.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CookManagement.VSA.Features.Users.UpdateUser;

public class UpdateUserHandler(CookDbContext context, PasswordHasher hasher)
{
    public async Task<UserResponse> HandleAsync(int userId, UserRequest request)
    {
        var currentUser = await context.Users
            .Where(u => u.Id == userId)
            .FirstOrDefaultAsync();

        if (currentUser is null)
            throw new CustomNotFoundException("El Usuario no fue encontrado.");

        var hashedPassword = hasher.HashPassword(request.Password);

        currentUser.Name = request.Name;
        currentUser.Role = request.Role;
        currentUser.Password = hashedPassword;

        await context.SaveChangesAsync();

        return currentUser.MapToUserResponse();
    }
}

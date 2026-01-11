using CookManagement.VSA.Infrastructure.Data;
using CookManagement.VSA.Infrastructure.Extensions;
using CookManagement.VSA.Shared.DTOs;
using CookManagement.VSA.Shared.Exceptions;
using Microsoft.EntityFrameworkCore;
namespace CookManagement.VSA.Features.Users.GetUserById;

public class GetUserByIdHandler(CookDbContext context)
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

using CookManagement.VSA.Infrastructure.Data;
using CookManagement.VSA.Shared.DTOs;
using Microsoft.EntityFrameworkCore;
namespace CookManagement.VSA.Features.Users.GetUsers;

public class GetUsersHandler(CookDbContext context)
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

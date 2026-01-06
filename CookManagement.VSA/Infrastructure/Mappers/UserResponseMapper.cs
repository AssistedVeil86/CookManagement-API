using CookManagement.VSA.Features.Authentication.Login;
using CookManagement.VSA.Shared.DTOs;
using CookManagement.VSA.Shared.Entities;

namespace CookManagement.VSA.Infrastructure.Mappers;

public static class UserResponseMapper
{
    public static UserResponse MapToDto(User user)
    {
        return new UserResponse()
        {
            UserId = user.Id,
            Name = user.Name,
            UserRole = user.Role
        };
    }
}

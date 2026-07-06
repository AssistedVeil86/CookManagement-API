using CookManagement.VSA.Domain.Enums;

namespace CookManagement.VSA.Features.Users.Shared
{
    public sealed record UserResponse
    {
        public int UserId { get; init; }
        public string Name { get; init; } = String.Empty;
        public UserRole UserRole { get; init; }
    }
}

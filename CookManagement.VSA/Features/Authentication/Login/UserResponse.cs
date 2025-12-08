using CookManagement.VSA.Shared.Enums;

namespace CookManagement.VSA.Features.Authentication.Login
{
    public sealed record UserResponse
    {
        public int UserId { get; init; }
        public string Name { get; init; } = String.Empty;
        public UserRole UserRole { get; init; }
    }
}

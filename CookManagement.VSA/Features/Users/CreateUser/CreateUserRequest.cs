using CookManagement.VSA.Shared.Enums;

namespace CookManagement.VSA.Features.Users.CreateUser;

public sealed record CreateUserRequest(string Name, string Password, UserRole Role);

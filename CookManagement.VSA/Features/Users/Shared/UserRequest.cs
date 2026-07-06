using CookManagement.VSA.Domain.Enums;

namespace CookManagement.VSA.Features.Users.Shared;

public sealed record UserRequest(string Name, string Password, UserRole Role);

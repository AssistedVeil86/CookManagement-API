using CookManagement.VSA.Shared.Enums;

namespace CookManagement.VSA.Shared.DTOs;

public sealed record UserRequest(string Name, string Password, UserRole Role);

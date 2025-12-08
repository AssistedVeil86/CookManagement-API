namespace CookManagement.VSA.Features.Authentication.Login
{
    public sealed record LoginRequest
    {
        public string Name { get; init; } = String.Empty;
        public string Password { get; init; } = String.Empty;
    }
}

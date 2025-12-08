namespace CookManagement.VSA.Features.Authentication.Login
{
    public sealed record TokenResponse
    {
        public string AccessToken { get; set; } = String.Empty;
        public DateTime Expiration { get; set; }
        public required UserResponse User { get; set; }
    }
}

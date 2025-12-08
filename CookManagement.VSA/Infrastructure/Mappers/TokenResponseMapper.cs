using CookManagement.VSA.Features.Authentication.Login;

namespace CookManagement.VSA.Infrastructure.Mappers
{
    public static class TokenResponseMapper
    {
        public static TokenResponse MapToDto(string accessToken, DateTime expiration, UserResponse user)
        {
            return new TokenResponse()
            {
                AccessToken = accessToken,
                Expiration = expiration,
                User = user
            };
        }
    }
}

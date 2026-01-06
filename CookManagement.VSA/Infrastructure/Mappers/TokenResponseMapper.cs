using CookManagement.VSA.Features.Authentication.Login;
using CookManagement.VSA.Shared.DTOs;

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

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CookManagement.VSA.Shared.Entities;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Extensions;

namespace CookManagement.VSA.Infrastructure.Auth
{
    public class TokenService
    {
        private readonly IConfiguration _configuration;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly string _secret;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;

            _issuer = _configuration["Jwt:Issuer"]!;
            _audience = _configuration["Jwt:Audience"]!;
            _secret = _configuration["Jwt:Secret"]!;
        }

        public string CreateAccessToken(User user)
        {
            var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Role, user.Role.GetDisplayName()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var accessToken = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                signingCredentials: credentials,
                expires: GetExpirationDate()
            );

            return new JwtSecurityTokenHandler().WriteToken(accessToken);
        }

        public DateTime GetExpirationDate()
        {
            return DateTime.Now.AddHours(1);
        }
    }
}

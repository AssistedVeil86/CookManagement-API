using CookManagement.VSA.Shared.Exceptions;
using System.Security.Claims;

namespace CookManagement.VSA.Infrastructure.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static int GetUserId(this ClaimsPrincipal user)
        {
            var userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim is null || !int.TryParse(userIdClaim.Value, out int userId))
            {
                throw new CustomInvalidAuthException("User not authenticated");
            }

            return userId;
        }

        public static string GetUserRole(this ClaimsPrincipal user)
        {
            var roleClaim = user.FindFirst(ClaimTypes.Role);

            if (roleClaim is null || roleClaim.Value == "")
            {
                throw new CustomInvalidAuthException("User not authenticated");
            }

            return roleClaim.Value;
        }
    }
}

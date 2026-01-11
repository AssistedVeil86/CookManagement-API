using CookManagement.VSA.Infrastructure.Auth;
using CookManagement.VSA.Infrastructure.Data;
using CookManagement.VSA.Infrastructure.Extensions;
using CookManagement.VSA.Shared.DTOs;
using CookManagement.VSA.Shared.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CookManagement.VSA.Features.Authentication.Login
{
    public class LoginHandler
    {
        private readonly CookDbContext _context;
        private readonly TokenService _tokenService;
        private readonly PasswordHasher _passwordHasher;
        private readonly ILogger<LoginHandler> _logger;

        public LoginHandler(CookDbContext context, TokenService tokenService, PasswordHasher passwordHasher, ILogger<LoginHandler> logger)
        {
            _context = context;
            _tokenService = tokenService;
            _passwordHasher = passwordHasher;
            _logger = logger;
        }

        public async Task<TokenResponse> HandleAsync(LoginRequest request)
        {
            _logger.LogInformation("El usuario {username} intenta iniciar sesión.", request.Name);

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Name == request.Name);

            if (user is null)
                throw new CustomNotFoundException("El Usuario no existe");

            if (!_passwordHasher.VerifyHashedPassword(user.Password, request.Password))
            {
                throw new CustomInvalidCredentialsException("Contraseña Invalida");
            }

            var accessToken = _tokenService.CreateAccessToken(user);
            
            var userResponse = new UserResponse()
            {
                UserId = user.Id,
                Name = user.Name,
                UserRole = user.Role
            };

            _logger.LogInformation("El Usuario {userName} con ID {userId} ha iniciado sesión exitosamente.",
                userResponse.Name, userResponse.UserId);

            return userResponse.MapToTokenResponse(accessToken, _tokenService.GetExpirationDate());
        }

    }
}

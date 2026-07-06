using CookManagement.VSA.Domain.Exceptions;
using CookManagement.VSA.Features.Users.Shared;
using CookManagement.VSA.Infrastructure.Auth;
using CookManagement.VSA.Infrastructure.Data;
using CookManagement.VSA.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace CookManagement.VSA.Features.Authentication.Login;

public static class LoginEndpoint
{
    public static RouteGroupBuilder MapLoginEndpoint(this RouteGroupBuilder route)
    {
        route.MapPost("login", Handler)
            .Produces<TokenResponse>()
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound)
            .WithRequestValidation<LoginRequest>();

        return route;
    }

    private static async Task<IResult> Handler(LoginHandler handler, LoginRequest request)
    {
        var result = await handler.HandleAsync(request);
        return Results.Ok(result);
    }
}

internal sealed class LoginHandler(
    CookDbContext context,
    TokenService tokenService,
    PasswordHasher passwordHasher,
    ILogger<LoginHandler> logger)
{
    public async Task<TokenResponse> HandleAsync(LoginRequest request)
    {
        logger.LogInformation("El usuario {username} intenta iniciar sesión.", request.Name);

        var user = await context.Users.FirstOrDefaultAsync(u => u.Name == request.Name) ?? throw new CustomNotFoundException("El Usuario no existe");
        if (!passwordHasher.VerifyHashedPassword(user.Password, request.Password))
        {
            throw new CustomInvalidCredentialsException("Contraseña Invalida");
        }

        var accessToken = tokenService.CreateAccessToken(user);

        var userResponse = new UserResponse()
        {
            UserId = user.Id,
            Name = user.Name,
            UserRole = user.Role
        };

        logger.LogInformation("El Usuario {userName} con ID {userId} ha iniciado sesión exitosamente.",
            userResponse.Name, userResponse.UserId);

        return userResponse.MapToTokenResponse(accessToken, tokenService.GetExpirationDate());
    }
}

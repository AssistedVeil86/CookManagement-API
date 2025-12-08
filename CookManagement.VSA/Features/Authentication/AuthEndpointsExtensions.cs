using CookManagement.VSA.Features.Authentication.Login;
using CookManagement.VSA.Infrastructure.Filters;

namespace CookManagement.VSA.Features.Authentication
{
    public static class AuthEndpointsExtensions
    {
        public static IServiceCollection RegisterAuthHandlers(this IServiceCollection services)
        {
            services.AddScoped<LoginHandler>();

            return services;
        }

        public static WebApplication MapAuthEndpoints(this WebApplication app)
        {
            var authGroup = app.MapGroup("api/auth")
                .WithTags("Authentication")
                .AddEndpointFilter<ExceptionFilter>();

            authGroup.MapLoginEndpoint();

            return app;
        }

    }
}

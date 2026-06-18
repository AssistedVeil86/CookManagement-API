using CookManagement.VSA.Infrastructure.Auth;
using CookManagement.VSA.Infrastructure.TimeZones;

namespace CookManagement.VSA.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<TokenService>();
            services.AddScoped<PasswordHasher>();
            services.AddScoped<TimeZoneService>();

            return services;
        }

        public static IServiceCollection ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy("AllowReact", builder =>
                builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

            return services;
        }
    }
}

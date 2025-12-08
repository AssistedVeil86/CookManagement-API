using CookManagement.VSA.Features.Users.GetUserRecords;
using CookManagement.VSA.Infrastructure.Filters;

namespace CookManagement.VSA.Features.Users
{
    public static class UserEndpointsExtensions
    {
        public static IServiceCollection RegisterUserHandlers(this IServiceCollection services)
        {
            services.AddScoped<GetUserRecordsHandler>();

            return services;
        }

        public static WebApplication MapUserEndpoints(this WebApplication app)
        {
            var userGroup = app.MapGroup("api/user/")
                .WithTags("Users")
                .AddEndpointFilter<ExceptionFilter>();

            userGroup.MapGetUserRecordsEndpoint();

            return app;
        }
    }
}

using CookManagement.VSA.Features.Users.CreateUser;
using CookManagement.VSA.Features.Users.GetUserById;
using CookManagement.VSA.Features.Users.GetUserRecords;
using CookManagement.VSA.Features.Users.GetUsers;
using CookManagement.VSA.Features.Users.UpdateUser;
using CookManagement.VSA.Infrastructure.Filters;

namespace CookManagement.VSA.Features.Users
{
    public static class UserEndpointsExtensions
    {
        public static IServiceCollection RegisterUserHandlers(this IServiceCollection services)
        {
            services.AddScoped<GetUserRecordsHandler>();
            services.AddScoped<CreateUserHandler>();
            services.AddScoped<UpdateUserHandler>();
            services.AddScoped<GetUserByIdHandler>();
            services.AddScoped<GetUsersHandler>();

            return services;
        }

        public static WebApplication MapUserEndpoints(this WebApplication app)
        {
            var userGroup = app.MapGroup("api/user/")
                .WithTags("Users")
                .AddEndpointFilter<ExceptionFilter>();

            userGroup.MapGetUserRecordsEndpoint();
            userGroup.MapCreateUserEndpoint();
            userGroup.MapUpdateUserEndpoint();
            userGroup.MapGetUserByIdEndpoint();
            userGroup.MapGetUsersEndpoint();

            return app;
        }
    }
}

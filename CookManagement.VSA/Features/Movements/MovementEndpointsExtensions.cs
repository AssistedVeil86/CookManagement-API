using CookManagement.VSA.Features.Movements.CreateInitialCount;
using CookManagement.VSA.Features.Movements.ModifyInitialCount;
using CookManagement.VSA.Features.Movements.RegisterMovements;
using CookManagement.VSA.Features.Movements.UpdateFinalCount;
using CookManagement.VSA.Infrastructure.Filters;

namespace CookManagement.VSA.Features.Movements
{
    public static class MovementEndpointsExtensions
    {
        public static IServiceCollection RegisterMovementsHandlers(this IServiceCollection services)
        {
            services.AddScoped<CreateInitialCountHandler>();
            services.AddScoped<RegisterMovementHandler>();
            services.AddScoped<UpdateFinalCountHandler>();
            services.AddScoped<ModifyInitialCountHandler>();

            return services;
        }

        public static WebApplication MapMovementsEndpoints(this WebApplication app)
        {
            var movementsGroup = app.MapGroup("api/movements")
                .WithTags("Movements")
                .AddEndpointFilter<ExceptionFilter>()
                .RequireAuthorization();

            movementsGroup.MapCreateInitialCountEndpoint();
            movementsGroup.MapRegisterMovementEndpoint();
            movementsGroup.MapUpdateFinalCountEndpoint();
            movementsGroup.MapModifyInitialCountEndpoint();

            return app;
        }
    }
}

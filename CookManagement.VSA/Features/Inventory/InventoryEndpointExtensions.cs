using CookManagement.VSA.Features.Inventory.GetByLowStock;
using CookManagement.VSA.Features.Inventory.GetInventory;
using CookManagement.VSA.Features.Inventory.UpdateStock;
using CookManagement.VSA.Infrastructure.Filters;

namespace CookManagement.VSA.Features.Inventory
{
    public static class InventoryEndpointExtensions
    {
        public static IServiceCollection RegisterInventoryHandlers(this IServiceCollection services)
        {
            services.AddScoped<GetInventoryHandler>();
            services.AddScoped<UpdateStockHandler>();
            services.AddScoped<GetByLowStockHandler>();

            return services;
        }

        public static WebApplication MapInventoryEndpoints(this WebApplication app)
        {
            var inventoryGroup = app.MapGroup("api/inventory")
                .WithTags("Inventory")
                .AddEndpointFilter<ExceptionFilter>();

            inventoryGroup.MapGetInventoryEndpoint();
            inventoryGroup.MapUpdateStockEndpoint();
            inventoryGroup.MapGetByLowStockEndpoint();

            return app;
        }
    }
}

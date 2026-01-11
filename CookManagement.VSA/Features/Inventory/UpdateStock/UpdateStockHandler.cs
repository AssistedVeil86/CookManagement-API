using CookManagement.VSA.Infrastructure.Data;
using CookManagement.VSA.Infrastructure.Extensions;
using CookManagement.VSA.Shared.Enums;
using CookManagement.VSA.Shared.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CookManagement.VSA.Features.Inventory.UpdateStock
{
    public class UpdateStockHandler
    {
        private readonly CookDbContext _context;
        private readonly ILogger<UpdateStockHandler> _logger;

        public UpdateStockHandler(CookDbContext context, ILogger<UpdateStockHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<InventoryItemResponse> HandleAsync(InventoryItemRequest request, string userRole)
        {
            var requestedType = DetermineInventoryType(userRole, request.InventoryType);

            var isKitchenRole = requestedType == InventoryType.Cocina;

            return isKitchenRole
                ? await UpdateKitchenProductStock(request.ProductName, request.NewStock)
                : await UpdateBarProductStock(request.ProductName, request.NewStock);
        }

        private InventoryType DetermineInventoryType(string userRole, InventoryType? requestedType)
        {
            return userRole switch
            {
                var role when role == nameof(UserRole.Admin) => requestedType ?? InventoryType.Cocina,
                var role when role == nameof(UserRole.Cocina) => InventoryType.Cocina,
                _ => InventoryType.Bar
            };
        }
        private async Task<InventoryItemResponse> UpdateBarProductStock(string productName, double newStock)
        {
            _logger.LogInformation("Se quiere actualizar el stock para el producto {productName}", productName);

            var product = await _context.BarInventory
                .FirstOrDefaultAsync(b => b.Product == productName);

            if (product is null)
                throw new CustomNotFoundException("Ese producto no existe en el inventario de Bar");

            product.CurrentStock = newStock;
            await _context.SaveChangesAsync();

            _logger.LogInformation("Se ha actualizado el stock para el producto {productName}: {productStock}",
                product.Product, product.CurrentStock);

            return MappingExtensions.MapToInvItemResponse(product.Code, product.Product, product.CurrentStock);
        }

        private async Task<InventoryItemResponse> UpdateKitchenProductStock(string productName, double newStock)
        {
            _logger.LogInformation("Se quiere actualizar el stock para el producto {productName}", productName);

            var product = await _context.KitchenInventory
                .FirstOrDefaultAsync(b => b.Product == productName);

            if (product is null)
                throw new CustomNotFoundException("Ese producto no existe en el inventario de Cocina");

            product.CurrentStock = newStock;
            await _context.SaveChangesAsync();

            _logger.LogInformation("Se ha actualizado el stock para el producto {productName}: {productStock}",
                product.Product, product.CurrentStock);

            return MappingExtensions.MapToInvItemResponse(product.Code, product.Product, product.CurrentStock);
        }

    }
}

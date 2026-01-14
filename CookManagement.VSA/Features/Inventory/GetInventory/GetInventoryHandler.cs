using CookManagement.VSA.Infrastructure.Data;
using CookManagement.VSA.Shared.Enums;
using CookManagement.VSA.Shared.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CookManagement.VSA.Features.Inventory.GetInventory
{
    public class GetInventoryHandler
    {
        private readonly CookDbContext _context;

        public GetInventoryHandler(CookDbContext context)
        {
            _context = context;
        }

        public async Task<InventoryPaginatedResponse> HandleAsync(
            int userId, string userRole, int page, int pageSize, InventoryType? inventoryType)
        {
            var userExists = await _context.Users.AnyAsync(u => u.Id == userId);
            if (!userExists)
                throw new CustomNotFoundException("El Usuario no existe");

            var requestedInventoryType = DetermineInventoryType(userRole, inventoryType);

            var inventory = await GetInventoryByType(requestedInventoryType, page, pageSize);
            var productCount = await CountInventoryByType(requestedInventoryType);

            return new InventoryPaginatedResponse()
            {
                Inventory = inventory,
                ProductCount = productCount,
            };
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

        private async Task<List<InventoryResponse>> GetInventoryByType(
            InventoryType requestedType, int page, int pageSize)
        {
            return requestedType == InventoryType.Cocina
                ? await GetKitchenInventory(page, pageSize)
                : await GetBarInventory(page, pageSize);
        }

        private async Task<int> CountInventoryByType(InventoryType requestedType)
        {
            return requestedType == InventoryType.Cocina
                ? await GetKitchenInventoryCount()
                : await GetBarInventoryCount();
        }

        private async Task<List<InventoryResponse>> GetKitchenInventory(int page, int pageSize)
        {
            return await _context.KitchenInventory.AsNoTracking()
                //.Where(x => EF.Functions.Like(x.Category, category))
                .OrderBy(x => x.Code)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(x => new InventoryResponse()
                {
                    Code = x.Code,
                    Product = x.Product,
                    Category = x.Category,
                    MeasurementUnit = x.MeasurementUnit,
                    CurrentStock = x.CurrentStock,
                    MinimumStock = x.MinimumStock
                }).ToListAsync();
        }

        private async Task<List<InventoryResponse>> GetBarInventory(int page, int pageSize)
        {
            return await _context.BarInventory.AsNoTracking()
                //.Where(x => EF.Functions.Like(x.Category, category))
                .OrderBy(x => x.Code)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(x => new InventoryResponse()
                {
                    Code = x.Code,
                    Product = x.Product,
                    Category = x.Category,
                    MeasurementUnit = null,
                    CurrentStock = x.CurrentStock,
                    MinimumStock = x.MinimumStock
                }).ToListAsync();
        }

        private async Task<int> GetKitchenInventoryCount()
        {
            return await _context.KitchenInventory.CountAsync();
        }

        private async Task<int> GetBarInventoryCount()
        {
            return await _context.BarInventory.CountAsync();
        }
    }
}

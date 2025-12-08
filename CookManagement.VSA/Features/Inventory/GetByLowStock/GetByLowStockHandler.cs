using System;
using CookManagement.VSA.Infrastructure.Data;
using CookManagement.VSA.Shared.Enums;
using CookManagement.VSA.Shared.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CookManagement.VSA.Features.Inventory.GetByLowStock;

public class GetByLowStockHandler
{
    private readonly CookDbContext _context;

    public GetByLowStockHandler(CookDbContext context)
    {
        _context = context;
    }

    public async Task<List<LowStockInventoryResponse>> HandleAsync(
        int userId, string userRole, InventoryType? inventoryType)
    {
        var userExists = await _context.Users.AnyAsync(u => u.Id == userId);
        if (!userExists)
            throw new CustomNotFoundException("El Usuario no existe");

        var requestedInventoryType = DetermineInventoryType(userRole, inventoryType);
        var inventory = await GetInventoryByType(requestedInventoryType);

        return inventory;
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

    private async Task<List<LowStockInventoryResponse>> GetInventoryByType(InventoryType requestedType)
    {
        return requestedType == InventoryType.Cocina
            ? await GetKitchenInventory()
            : await GetBarInventory();
    }

    private async Task<List<LowStockInventoryResponse>> GetKitchenInventory()
    {
        return await _context.KitchenInventory
            .Where(x => x.CurrentStock <= x.MinimumStock)
            .Select(x => new LowStockInventoryResponse
            {
                Code = x.Code,
                Product = x.Product,
                Category = x.Category,
                MeasurementUnit = x.MeasurementUnit,
                CurrentStock = x.CurrentStock,
                MinimumStock = x.MinimumStock
            })
            .ToListAsync();
    }

    private async Task<List<LowStockInventoryResponse>> GetBarInventory()
    {
        return await _context.BarInventory
            .Where(x => x.CurrentStock <= x.MinimumStock)
            .Select(x => new LowStockInventoryResponse
            {
                Code = x.Code,
                Product = x.Product,
                Category = x.Category,
                MeasurementUnit = null,
                CurrentStock = x.CurrentStock,
                MinimumStock = x.MinimumStock
            })
            .ToListAsync();
    }
}

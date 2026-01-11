using CookManagement.VSA.Infrastructure.Data;
using CookManagement.VSA.Infrastructure.Mappers;
using CookManagement.VSA.Infrastructure.TimeZones;
using CookManagement.VSA.Shared.DTOs;
using CookManagement.VSA.Shared.Entities;
using CookManagement.VSA.Shared.Enums;
using CookManagement.VSA.Shared.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CookManagement.VSA.Features.Movements.UpdateFinalCount
{
    public class UpdateFinalCountHandler
    {
        private readonly CookDbContext _context;
        private readonly TimeZoneService _timeZoneService;
        private readonly ILogger<UpdateFinalCountHandler> _logger;

        public UpdateFinalCountHandler(
            CookDbContext context,
            ILogger<UpdateFinalCountHandler> logger,
            TimeZoneService timeZoneService)
        {
            _context = context;
            _logger = logger;
            _timeZoneService = timeZoneService;
        }

        public async Task<FinalCountResponse> HandleAsync(int userId, string userRole, CountRequest request)
        {
            _logger.LogInformation("El usuario con ID {userId} quiere registrar el inventario final " +
                                   "para el producto con código {productCode}, con cantidad: {count}"
                , userId, request.ProductCode, request.Count);

            if (request.Count < 0)
                throw new CustomConflictException("El conteo final no puede ser negativo");

            var (startOfDayUtc, endOfDayUtc) = _timeZoneService.GetTodayBoundariesInUtc(request.TimeZoneId);

            var inventoryType = userRole == nameof(UserRole.Cocina) ? InventoryType.Cocina : InventoryType.Bar;

            var userRecord = await _context.UserRecords
                .Where(r => r.UserId == userId
                        && r.CreatedAt >= startOfDayUtc
                        && r.CreatedAt < endOfDayUtc
                        && r.InventoryType == inventoryType
                        && r.ProductCode == request.ProductCode)
                .FirstOrDefaultAsync();

            if (userRecord is null)
                throw new CustomNotFoundException("No existe registro para este producto");

            if (userRecord.FinalInventory > 0)
                throw new CustomInvalidOperationException("El Inventario Final para ese product ya ha sido creado hoy");

            var utcNow = DateTime.UtcNow;
            var dailyMove = CalculateDailyMovement(userRecord);

            userRecord.FinalInventory = request.Count;
            userRecord.Difference = CalculateDifference(userRecord, dailyMove);
            userRecord.DailyMove = dailyMove;
            userRecord.UpdatedAt = utcNow;

            await UpdateInventoryProductStock(inventoryType, request.ProductCode, request.Count);

            await _context.SaveChangesAsync();

            _logger.LogInformation("El usuario con ID {userId} ha registrado exitosamente el inventario final " +
                                   "para el producto con código {productCode}, con cantidad: {count}"
                , userId, request.ProductCode, request.Count);

            return FinalCountMapper.MapToDto(userRecord);
        }

        private Double CalculateDifference(UserRecord record, double dailyMove)
        {
            var sales = dailyMove - record.FinalInventory;

            return sales;
        }

        private Double CalculateDailyMovement(UserRecord record)
        {
            return record.InitialInventory + record.Entries - (record.Damaged + record.Courtesy + record.Remains);
        }

        private async Task UpdateInventoryProductStock(InventoryType inventoryType, string code, Double finalCount)
        {
            BaseInventory? inventoryItem = null;

            if (inventoryType == InventoryType.Cocina)
            {
                inventoryItem = await _context.KitchenInventory.FirstOrDefaultAsync(i => i.Code == code);
            }
            else
            {
                inventoryItem = await _context.BarInventory.FirstOrDefaultAsync(i => i.Code == code);
            }

            if (inventoryItem is null)
                throw new CustomNotFoundException($"El Producto con código {code} no existe en " +
                    $"el Inventario de {inventoryType}");

            if (inventoryItem.CurrentStock < finalCount || inventoryItem.CurrentStock == 0)
                throw new CustomInvalidOperationException("El Conteo Final no puede ser mayor al Stock");

            inventoryItem.CurrentStock -= finalCount;
        }
    }
}

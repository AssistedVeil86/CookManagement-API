using CookManagement.VSA.Infrastructure.Data;
using CookManagement.VSA.Infrastructure.Mappers;
using CookManagement.VSA.Infrastructure.TimeZones;
using CookManagement.VSA.Shared.Entities;
using CookManagement.VSA.Shared.Enums;
using CookManagement.VSA.Shared.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CookManagement.VSA.Features.Movements.RegisterMovements
{
    public class RegisterMovementHandler
    {
        private readonly CookDbContext _context;
        private readonly TimeZoneService _timeZoneService;
        private readonly ILogger<RegisterMovementHandler> _logger;

        public RegisterMovementHandler(
            CookDbContext context,
            ILogger<RegisterMovementHandler> logger,
            TimeZoneService timeZoneService)
        {
            _context = context;
            _logger = logger;
            _timeZoneService = timeZoneService;
        }

        public async Task<MovementResponse> HandleAsync(int userId, string userRole, MovementRequest request)
        {

            _logger.LogInformation("El usuario con ID {userId} quiere registrar un " +
                                   "movimiento: {movement}, con cantidad: {count}"
                , userId, request.MovementType, request.MovementCount);

            var inventoryType = userRole == nameof(UserRole.Cocina)
                ? InventoryType.Cocina
                : InventoryType.Bar;

            var (startOfDayUtc, endOfDayUtc) = _timeZoneService.GetTodayBoundariesInUtc(request.TimeZoneId);

            var userRecord = await _context.UserRecords
                .Where(r => r.UserId == userId
                        && r.CreatedAt >= startOfDayUtc
                        && r.CreatedAt < endOfDayUtc
                        && r.InventoryType == inventoryType
                        && r.ProductCode == request.ProductCode)
                .FirstOrDefaultAsync();

            if (userRecord is null)
                throw new CustomNotFoundException("No existe registro para este producto");

            var movementCount = await RegisterMovementType(userRecord, request, inventoryType);
            var utcNow = DateTime.UtcNow;

            userRecord.UpdatedAt = utcNow;

            await _context.SaveChangesAsync();

            _logger.LogInformation("El usuario con ID {userId} ha registrado exitosamente un " +
                                   "movimiento de tipo: {movement}, con cantidad: {count}"
                , userId, request.MovementType, movementCount);

            return MovementResponseMapper
                .MapToDto(userRecord.ProductCode, movementCount, request.MovementType);
        }

        private async Task<Double> RegisterMovementType(UserRecord record, MovementRequest request, InventoryType inventoryType)
        {
            return request.MovementType switch
            {
                MovementType.Courtesy => record.Courtesy += request.MovementCount,
                MovementType.Damaged => record.Damaged += request.MovementCount,
                MovementType.Entry => await UpdateStockForEntry(record, request, inventoryType),
                MovementType.Remains => record.Remains += request.MovementCount,
                _ => throw new CustomInvalidOperationException("Tipo de Movimiento Inválido")
            };
        }

        private async Task<Double> UpdateStockForEntry(UserRecord record, MovementRequest request, InventoryType inventoryType)
        {
            BaseInventory? inventoryItem = null;

            if (inventoryType == InventoryType.Cocina)
            {
                inventoryItem = await _context.KitchenInventory
                    .FirstOrDefaultAsync(i => i.Code == request.ProductCode);
            }
            else
            {
                inventoryItem = await _context.BarInventory
                    .FirstOrDefaultAsync(i => i.Code == request.ProductCode);
            }

            if (inventoryItem is null)
                throw new CustomNotFoundException($"El Producto con código {request.ProductCode} no existe en " +
                    $"el Inventario de {inventoryType}");

            var entries = record.Entries + request.MovementCount;
            inventoryItem.CurrentStock += entries;

            return entries;
        }
    }
}

using CookManagement.VSA.Infrastructure.Data;
using CookManagement.VSA.Infrastructure.Mappers;
using CookManagement.VSA.Infrastructure.TimeZones;
using CookManagement.VSA.Shared.DTOs;
using CookManagement.VSA.Shared.Entities;
using CookManagement.VSA.Shared.Enums;
using CookManagement.VSA.Shared.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CookManagement.VSA.Features.Movements.CreateInitialCount
{
    public class CreateInitialCountHandler
    {
        private readonly CookDbContext _context;
        private readonly TimeZoneService _timeZoneService;
        private readonly ILogger<CreateInitialCountHandler> _logger;

        public CreateInitialCountHandler(
            CookDbContext context,
            ILogger<CreateInitialCountHandler> logger,
            TimeZoneService timeZoneService)
        {
            _context = context;
            _logger = logger;
            _timeZoneService = timeZoneService;
        }

        public async Task<InitialCountResponse> HandleAsync(
            int userId, string userRole, CountRequest request)
        {

            if (request.Count < 0)
                throw new CustomInvalidOperationException("El Conteo Inicial no puede ser negativo");

            var (startOfDayUtc, endOfDayUtc) = _timeZoneService.GetTodayBoundariesInUtc(request.TimeZoneId);

            var todayRecord = await _context.UserRecords
                .Where(r => r.UserId == userId
                        && r.CreatedAt >= startOfDayUtc
                        && r.CreatedAt < endOfDayUtc
                        && r.ProductCode == request.ProductCode)
                .AnyAsync();


            if (todayRecord)
                throw new CustomConflictException("El Inventario Inicial para ese Producto ya ha sido creado");

            var user = await _context.Users.FindAsync(userId);

            if (user is null)
                throw new CustomNotFoundException("El Usuario no existe");

            var inventoryType = userRole == nameof(UserRole.Cocina)
                        ? InventoryType.Cocina
                        : InventoryType.Bar;

            var inventoryProduct = await GetInventoryProductNameByType(inventoryType, request.ProductCode);

            if (request.Count > inventoryProduct.CurrentStock || request.Count < inventoryProduct.CurrentStock)
                throw new CustomInvalidOperationException("El Conteo Inicial es Inválido");
            
            _logger.LogInformation("El usuario {userName} con ID {userId} quiere registrar el " +
                                   "inventario inicial para el producto con codigo {productCode}",
                user.Name, user.Id, request.ProductCode);

            var utcNow = DateTime.UtcNow;

            var userRecord = new UserRecord()
            {
                UserId = user.Id,
                User = user,
                ProductCode = request.ProductCode,
                ProductName = inventoryProduct.Product,
                InitialInventory = request.Count,
                FinalInventory = 0,
                Difference = 0,
                DailyMove = 0,
                Entries = 0,
                Courtesy = 0,
                Damaged = 0,
                Remains = 0,
                InventoryType = inventoryType,
                CreatedAt = utcNow,
                UpdatedAt = utcNow,
            };

            _context.UserRecords.Add(userRecord);
            await _context.SaveChangesAsync();

            _logger.LogInformation("El usuario {userName} con ID {userID} ha registrado existosamente el " +
                                   "inventario inicial para el producto con codigo {productCode}",
                user.Name, request.ProductCode, user.Id);

            return InitialCountMapper.MapToDto(userRecord);
        }

        private async Task<BaseInventory> GetInventoryProductNameByType(InventoryType inventoryType, string code)
        {
            return inventoryType switch
            {
                InventoryType.Cocina => await _context.KitchenInventory
                    .Where(p => p.Code == code)
                    .Select(p => new BaseInventory
                    {
                        Product = p.Product,
                        CurrentStock = p.CurrentStock
                    })
                    .FirstOrDefaultAsync()
                    ?? throw new CustomNotFoundException("El producto no existe en el inventario de cocina"),

                InventoryType.Bar => await _context.BarInventory
                    .Where(p => p.Code == code)
                    .Select(p => new BaseInventory
                    {
                        Product = p.Product,
                        CurrentStock = p.CurrentStock
                    })
                    .FirstOrDefaultAsync()
                    ?? throw new CustomNotFoundException("El producto no existe en el inventario de bar"),

                _ => throw new CustomInvalidOperationException("Tipo de inventario no válido"),
            };
        }
    }
}

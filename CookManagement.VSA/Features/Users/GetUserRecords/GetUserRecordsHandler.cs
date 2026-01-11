using CookManagement.VSA.Infrastructure.Data;
using CookManagement.VSA.Infrastructure.TimeZones;
using CookManagement.VSA.Shared.Enums;
using CookManagement.VSA.Shared.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CookManagement.VSA.Features.Users.GetUserRecords
{
    public class GetUserRecordsHandler
    {
        private readonly CookDbContext _context;
        private readonly TimeZoneService _timeZoneService;

        public GetUserRecordsHandler(
            CookDbContext context,
            TimeZoneService timeZoneService)
        {
            _context = context;
            _timeZoneService = timeZoneService;
        }

        public async Task<RecordsPaginatedResponse> HandleAsync(
            string userName, DateTime requestedDate, string timeZoneId, int page, int pageSize)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Name == userName);

            if (user is null)
                throw new CustomNotFoundException("Ese usuario no existe");

            var inventoryType = user.Role == UserRole.Cocina
                ? InventoryType.Cocina
                : InventoryType.Bar;

            //var (startOfDayUtc, endOfDayUtc) = _timeZoneService.GetTodayBoundariesInUtc(timeZoneId);

            //var baseQuery = _context.UserRecords.AsNoTracking()
            //    .Where(r => r.UserId == user.Id
            //            && r.CreatedAt >= startOfDayUtc
            //            && r.CreatedAt < endOfDayUtc
            //            && r.InventoryType == inventoryType);

            var utcRequestedDate = requestedDate.ToUniversalTime();

            var baseQuery = _context.UserRecords.AsNoTracking()
                .Where(r => r.UserId == user.Id
                        && r.CreatedAt == utcRequestedDate
                        && r.InventoryType == inventoryType);

            var userRecords = await baseQuery
                .OrderBy(r => r.ProductCode)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(r => new UserRecordsResponse()
                {
                    UserId = r.UserId,
                    ProductCode = r.ProductCode,
                    ProductName = r.ProductName,
                    InitialInventory = r.InitialInventory,
                    FinalInventory = r.FinalInventory,
                    Difference = r.Difference,
                    DailyMove = r.DailyMove,
                    Entries = r.Entries,
                    Damaged = r.Damaged,
                    Courtesy = r.Courtesy,
                    Remains = r.Remains
                }).ToListAsync();


            var recordsCount = baseQuery.Count();

            return new RecordsPaginatedResponse()
            {
                UserRecords = userRecords,
                RecordsCount = recordsCount
            };
        }
    }
}

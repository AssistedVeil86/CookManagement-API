using CookManagement.VSA.Domain.Enums;
using CookManagement.VSA.Domain.Exceptions;
using CookManagement.VSA.Infrastructure.Data;
using CookManagement.VSA.Infrastructure.TimeZones;
using Microsoft.EntityFrameworkCore;

namespace CookManagement.VSA.Features.Users.GetUserRecords;

public static class GetUserRecordsEndpoint
{
    public static RouteGroupBuilder MapGetUserRecordsEndpoint(this RouteGroupBuilder route)
    {
        route.MapGet("records", Handler)
            .Produces<RecordsPaginatedResponse>()
            .RequireAuthorization("AdminOnly");

        return route;
    }

    private static async Task<IResult> Handler(
        GetUserRecordsHandler handler, string userName,
        DateTime requestedDate, string timeZoneId, InventoryType? inventoryType, int page = 1, int pageSize = 12)
    {
        var results = await handler
            .HandleAsync(userName, requestedDate, timeZoneId, inventoryType, page, pageSize);
        return Results.Ok(results);
    }
}

internal sealed class GetUserRecordsHandler(
    CookDbContext context,
    TimeZoneService timeZoneService)
{
    public async Task<RecordsPaginatedResponse> HandleAsync(
        string userName, DateTime requestedDate, string timeZoneId,
        InventoryType? inventoryType, int page, int pageSize)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.Name == userName);

        if (user is null)
            throw new CustomNotFoundException("Ese usuario no existe");

        var resolvedInventoryType = inventoryType
            ?? (user.Role == UserRole.Cocina ? InventoryType.Cocina : InventoryType.Bar);

        var (startOfDayUtc, endOfDayUtc) = timeZoneService.GetCurrentDateBoundariesInUtc(timeZoneId, requestedDate);

        var baseQuery = context.UserRecords.AsNoTracking()
            .Where(r => r.UserId == user.Id
                    && r.CreatedAt >= startOfDayUtc
                    && r.CreatedAt < endOfDayUtc
                    && r.InventoryType == resolvedInventoryType);

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

using System.Security.Claims;
using CookManagement.VSA.Domain.Enums;
using CookManagement.VSA.Domain.Exceptions;
using CookManagement.VSA.Features.Movements.Shared;
using CookManagement.VSA.Infrastructure.Data;
using CookManagement.VSA.Infrastructure.Extensions;
using CookManagement.VSA.Infrastructure.TimeZones;
using Microsoft.EntityFrameworkCore;

namespace CookManagement.VSA.Features.Movements.ModifyInitialCount;

public static class ModifyInitialCountEndpoint
{
    public static RouteGroupBuilder MapModifyInitialCountEndpoint(this RouteGroupBuilder route)
    {
        route.MapPut("modify-initial-count", Handler);

        return route;
    }

    private static async Task<IResult> Handler(
        ModifyInitialCountHandler handler, ClaimsPrincipal user, CountRequest request, InventoryType? inventoryType)
    {
        var userId = user.GetUserId();
        var userRole = user.GetUserRole();

        var result = await handler.HandleAsync(userId, userRole, request, inventoryType);
        return Results.Ok(result);
    }
}

internal sealed class ModifyInitialCountHandler(
    CookDbContext context,
    TimeZoneService timeZoneService,
    ILogger<ModifyInitialCountHandler> logger)
{
    public async Task<InitialCountResponse> HandleAsync(
        int userId, string userRole, CountRequest request, InventoryType? inventoryType)
    {
        if (request.Count < 0)
            throw new CustomInvalidOperationException("El Conteo Inicial no puede ser negativo");

        var (startOfDayUtc, endOfDayUtc) = timeZoneService.GetTodayBoundariesInUtc(request.TimeZoneId);

        var resolvedInventoryType = inventoryType
            ?? (userRole == nameof(UserRole.Cocina) ? InventoryType.Cocina : InventoryType.Bar);

        var todayRecord = await context.UserRecords
            .FirstOrDefaultAsync(r => r.CreatedAt >= startOfDayUtc &&
                                r.CreatedAt < endOfDayUtc &&
                                r.UserId == userId &&
                                r.InventoryType == resolvedInventoryType &&
                                r.ProductCode == request.ProductCode)
        ?? throw new CustomNotFoundException("No se encontró un registro de inventario inicial para el producto especificado");

        todayRecord.InitialInventory = request.Count;
        todayRecord.UpdatedAt = DateTimeOffset.UtcNow;
        await context.SaveChangesAsync();

        logger.LogInformation("El usuario con ID {userId} ha modificado el inventario inicial " +
                               "para el producto con código {productCode}, con cantidad: {count}",
                               userId, request.ProductCode, request.Count);

        return todayRecord.MapToInitialCount();
    }
}

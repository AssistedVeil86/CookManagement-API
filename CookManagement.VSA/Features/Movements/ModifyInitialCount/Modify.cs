using System.Security.Claims;
using CookManagement.VSA.Infrastructure.Data;
using CookManagement.VSA.Infrastructure.Extensions;
using CookManagement.VSA.Infrastructure.TimeZones;

namespace CookManagement.VSA.Features.Movements.ModifyInitialCount;

public static class ModifyInitialCountEndpoint
{
    public static RouteGroupBuilder MapModifyInitialCountEndpoint(this RouteGroupBuilder route)
    {
        route.MapPut("modify-initial-count", Handler);

        return route;
    }

    private static async Task<IResult> Handler(
        ModifyInitialCountHandler handler, ClaimsPrincipal user)
    {
        var userId = user.GetUserId();
        var userRole = user.GetUserRole();

        var result = await handler.HandleAsync(userId, userRole);
        return Results.Ok(result);
    }
}

internal sealed class ModifyInitialCountHandler(
    CookDbContext context,
    TimeZoneService timeZoneService,
    ILogger<ModifyInitialCountHandler> logger)
{
    private readonly CookDbContext _context = context;
    private readonly TimeZoneService _timeZoneService = timeZoneService;
    private readonly ILogger<ModifyInitialCountHandler> _logger = logger;

    public async Task<ModifyCountResponse> HandleAsync(int userId, string userRole)
    {
        throw new NotImplementedException();
    }
}

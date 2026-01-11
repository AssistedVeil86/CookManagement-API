using System;

namespace CookManagement.VSA.Features.Movements.CreateInitialCount;

public sealed record InitialCountRequest
{
    public string ProductCode { get; init; } = string.Empty;
    public Double Count { get; init; }
    public string? TimeZoneId { get; init; } = string.Empty;
}

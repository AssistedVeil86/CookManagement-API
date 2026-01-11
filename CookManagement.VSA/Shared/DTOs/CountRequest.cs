using System;

namespace CookManagement.VSA.Shared.DTOs;

public sealed record CountRequest
{
    public string ProductCode { get; init; } = string.Empty;
    public Double Count { get; init; }
    public string? TimeZoneId { get; init; } = string.Empty;
}

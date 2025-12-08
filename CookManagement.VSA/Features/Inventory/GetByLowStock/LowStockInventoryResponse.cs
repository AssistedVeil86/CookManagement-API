using System;

namespace CookManagement.VSA.Features.Inventory.GetByLowStock;

public sealed record LowStockInventoryResponse
{
    public string Code { get; init; } = String.Empty;
    public string Product { get; init; } = String.Empty;
    public string Category { get; init; } = String.Empty;
    public string? MeasurementUnit { get; init; } = String.Empty;
    public int CurrentStock { get; init; }
    public int MinimumStock { get; init; }
}

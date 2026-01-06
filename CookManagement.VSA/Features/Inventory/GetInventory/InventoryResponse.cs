namespace CookManagement.VSA.Features.Inventory.GetInventory
{
    public sealed record InventoryResponse
    {
        public string Code { get; init; } = String.Empty;
        public string Product { get; init; } = String.Empty;
        public string Category { get; init; } = String.Empty;
        public string? MeasurementUnit { get; init; } = String.Empty;
        public double CurrentStock { get; init; }
        public double MinimumStock { get; init; }
    }
}

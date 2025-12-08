namespace CookManagement.VSA.Features.Inventory.UpdateStock
{
    public sealed record InventoryItemResponse
    {
        public string Code { get; init; } = String.Empty;
        public string Product { get; init; } = String.Empty;
        public int CurrentStock { get; init; }
    }
}

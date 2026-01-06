using CookManagement.VSA.Shared.Enums;

namespace CookManagement.VSA.Features.Inventory.UpdateStock
{
    public sealed record InventoryItemRequest
    {
        public string ProductName { get; init; } = String.Empty;
        public double NewStock { get; init; }
        public InventoryType InventoryType { get; init; }
    }
}

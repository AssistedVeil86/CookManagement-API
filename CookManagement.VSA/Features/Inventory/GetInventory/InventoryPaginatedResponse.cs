namespace CookManagement.VSA.Features.Inventory.GetInventory
{
    public sealed record InventoryPaginatedResponse
    {
        public InventoryPaginatedResponse()
        {
            Inventory = new List<InventoryResponse>();
        }

        public List<InventoryResponse> Inventory { get; init; }
        public int ProductCount { get; init; }
    }
}

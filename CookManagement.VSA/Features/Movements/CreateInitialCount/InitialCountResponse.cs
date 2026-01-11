using CookManagement.VSA.Shared.Enums;

namespace CookManagement.VSA.Features.Movements.CreateInitialCount
{
    public sealed record InitialCountResponse
    {
        public int UserId { get; init; }
        public string ProductCode { get; init; } = String.Empty;
        public Double InitialInventory { get; init; } = 0;
        public InventoryType InventoryType { get; init; }
        public DateTimeOffset CreatedAt { get; init; }
        public DateTimeOffset UpdatedAt { get; init; }
    }
}

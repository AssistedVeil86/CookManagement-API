using CookManagement.VSA.Shared.Enums;

namespace CookManagement.VSA.Features.Movements.UpdateFinalCount
{
    public sealed record FinalCountResponse
    {
        public int UserId { get; init; }
        public string ProductCode { get; init; } = String.Empty;
        public Double FinalInventory { get; init; } = 0;
        public Double Difference { get; init; } = 0;
        public Double DailyMove { get; init; } = 0;
        public InventoryType InventoryType { get; init; }
        public DateTimeOffset CreatedAt { get; init; }
        public DateTimeOffset UpdatedAt { get; init; }
    }
}

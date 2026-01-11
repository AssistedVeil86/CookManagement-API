using CookManagement.VSA.Shared.Enums;

namespace CookManagement.VSA.Shared.Entities
{
    public class UserRecord : BaseEntity
    {
        public int UserId { get; set; }
        public required User User { get; set; }
        public string ProductCode { get; set; } = String.Empty;
        public string ProductName { get; set; } = String.Empty;
        public Double InitialInventory { get; set; } = 0;
        public Double FinalInventory { get; set; } = 0;
        public Double Difference { get; set; } = 0;
        public Double DailyMove { get; set; } = 0;
        public int Entries { get; set; } = 0;
        public Double Courtesy { get; set; } = 0;
        public Double Damaged { get; set; } = 0;
        public Double Remains { get; set; } = 0;
        public InventoryType InventoryType { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}

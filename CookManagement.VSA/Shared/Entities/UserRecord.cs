using CookManagement.VSA.Shared.Enums;

namespace CookManagement.VSA.Shared.Entities
{
    public class UserRecord : BaseEntity
    {
        public int UserId { get; set; }
        public required User User { get; set; }
        public string ProductCode { get; set; } = String.Empty;
        public string ProductName { get; set; } = String.Empty;
        public int InitialInventory { get; set; } = 0;
        public int FinalInventory { get; set; } = 0;
        public int Difference { get; set; } = 0;
        public int DailyMove { get; set; } = 0;
        public int Entries { get; set; } = 0;
        public int Courtesy { get; set; } = 0;
        public int Damaged { get; set; } = 0;
        public int Remains { get; set; } = 0;
        public InventoryType InventoryType { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}

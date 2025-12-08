namespace CookManagement.VSA.Shared.Entities
{
    public class BarInventory : BaseInventory
    {
        public string Category { get; set; } = String.Empty;
        public int MinimumStock { get; set; } = 0;
    }
}

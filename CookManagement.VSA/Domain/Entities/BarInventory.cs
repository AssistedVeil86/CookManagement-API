namespace CookManagement.VSA.Domain.Entities
{
    public class BarInventory : BaseInventory
    {
        public string Category { get; set; } = String.Empty;
        public double MinimumStock { get; set; } = 0;
    }
}

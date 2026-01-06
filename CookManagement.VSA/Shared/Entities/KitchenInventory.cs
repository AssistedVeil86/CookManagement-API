namespace CookManagement.VSA.Shared.Entities
{
    public class KitchenInventory : BaseInventory
    {
        public string Category { get; set; } = String.Empty;
        public string MeasurementUnit { get; set; } = String.Empty;
        public double MinimumStock { get; set; } = 0;
    }
}

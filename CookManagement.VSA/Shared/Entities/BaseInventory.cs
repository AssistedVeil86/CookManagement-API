namespace CookManagement.VSA.Shared.Entities
{
    public class BaseInventory
    {
        public string Code { get; set; } = String.Empty;
        public string Product { get; set; } = String.Empty;
        public double CurrentStock { get; set; } = 0;
    }
}

using CookManagement.VSA.Features.Inventory.UpdateStock;

namespace CookManagement.VSA.Infrastructure.Mappers
{
    public static class InventoryItemMapper
    {
        public static InventoryItemResponse MapToDto(string code, string productName, int newStock)
        {
            return new InventoryItemResponse()
            {
                Code = code,
                Product = productName,
                CurrentStock = newStock
            };
        }
    }
}

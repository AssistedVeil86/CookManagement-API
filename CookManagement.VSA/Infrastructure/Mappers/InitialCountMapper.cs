using CookManagement.VSA.Features.Movements.CreateInitialCount;
using CookManagement.VSA.Shared.Entities;

namespace CookManagement.VSA.Infrastructure.Mappers
{
    public static class InitialCountMapper
    {
        public static InitialCountResponse MapToDto(UserRecord record)
        {
            return new InitialCountResponse()
            {
                UserId = record.UserId,
                ProductCode = record.ProductCode,
                InitialInventory = record.InitialInventory,
                InventoryType = record.InventoryType,
                CreatedAt = record.CreatedAt,
                UpdatedAt = record.UpdatedAt,
            };
        }
    }
}

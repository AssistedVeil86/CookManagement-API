using CookManagement.VSA.Features.Movements.UpdateFinalCount;
using CookManagement.VSA.Shared.Entities;

namespace CookManagement.VSA.Infrastructure.Mappers
{
    public static class FinalCountMapper
    {
        public static FinalCountResponse MapToDto(UserRecord record)
        {
            return new FinalCountResponse()
            {
                UserId = record.UserId,
                ProductCode = record.ProductCode,
                FinalInventory = record.FinalInventory,
                Difference = record.Difference,
                DailyMove = record.DailyMove,
                InventoryType = record.InventoryType,
                CreatedAt = record.CreatedAt,
                UpdatedAt = record.UpdatedAt
            };
        }

    }
}

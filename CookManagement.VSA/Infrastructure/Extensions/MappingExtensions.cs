using CookManagement.VSA.Features.Authentication.Login;
using CookManagement.VSA.Features.Inventory.UpdateStock;
using CookManagement.VSA.Features.Movements.CreateInitialCount;
using CookManagement.VSA.Features.Movements.RegisterMovements;
using CookManagement.VSA.Features.Movements.UpdateFinalCount;
using CookManagement.VSA.Shared.DTOs;
using CookManagement.VSA.Shared.Entities;
using CookManagement.VSA.Shared.Enums;

namespace CookManagement.VSA.Infrastructure.Extensions
{
    public static class MappingExtensions
    {
        public static FinalCountResponse MapToFinalCount(this UserRecord record)
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

        public static InitialCountResponse MapToInitialCount(this UserRecord record)
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

        public static UserResponse MapToUserResponse(this User user)
        {
            return new UserResponse()
            {
                UserId = user.Id,
                Name = user.Name,
                UserRole = user.Role
            };
        }

        public static TokenResponse MapToTokenResponse(this UserResponse user, string accessToken, DateTime expiration)
        {
            return new TokenResponse()
            {
                AccessToken = accessToken,
                Expiration = expiration,
                User = user
            };
        }

        public static InventoryItemResponse MapToInvItemResponse(string code, string productName, double newStock)
        {
            return new InventoryItemResponse()
            {
                Code = code,
                Product = productName,
                CurrentStock = newStock
            };
        }

        public static MovementResponse MapToMovementResponse(string productCode, Double count, MovementType movementType)
        {
            return new MovementResponse()
            {
                ProductCode = productCode,
                MovementType = movementType,
                MovementCount = count
            };
        }
    }
}

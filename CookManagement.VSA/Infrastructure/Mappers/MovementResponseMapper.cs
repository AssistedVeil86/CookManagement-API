using CookManagement.VSA.Features.Movements.RegisterMovements;
using CookManagement.VSA.Shared.Enums;

namespace CookManagement.VSA.Infrastructure.Mappers
{
    public static class MovementResponseMapper
    {
        public static MovementResponse MapToDto(string productCode, int count, MovementType movementType)
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

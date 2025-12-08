using CookManagement.VSA.Shared.Enums;

namespace CookManagement.VSA.Features.Movements.RegisterMovements
{
    public sealed record MovementRequest
    {
        public string ProductCode { get; init; } = String.Empty;
        public MovementType MovementType { get; init; }
        public int MovementCount { get; init; }
        public string? TimeZoneId { get; init; } = string.Empty;
    }
}

using CookManagement.VSA.Shared.Enums;

namespace CookManagement.VSA.Features.Movements.RegisterMovements
{
    public sealed record MovementResponse
    {
        public string ProductCode { get; set; } = String.Empty;
        public MovementType MovementType { get; set; }
        public Double MovementCount { get; set; }
    }
}

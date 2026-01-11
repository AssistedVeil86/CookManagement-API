namespace CookManagement.VSA.Features.Users.GetUserRecords
{
    public sealed record UserRecordsResponse
    {
        public int UserId { get; init; }
        public string ProductCode { get; init; } = String.Empty;
        public string ProductName { get; init; } = String.Empty;
        public Double InitialInventory { get; init; } = 0;
        public Double FinalInventory { get; init; } = 0;
        public Double Difference { get; init; } = 0;
        public Double DailyMove { get; init; } = 0;
        public int Entries { get; init; } = 0;
        public Double Courtesy { get; init; } = 0;
        public Double Damaged { get; init; } = 0;
        public Double Remains { get; init; } = 0;
    }
}

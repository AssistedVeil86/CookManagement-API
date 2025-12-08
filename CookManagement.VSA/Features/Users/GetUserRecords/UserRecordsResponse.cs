namespace CookManagement.VSA.Features.Users.GetUserRecords
{
    public sealed record UserRecordsResponse
    {
        public int UserId { get; init; }
        public string ProductCode { get; init; } = String.Empty;
        public string ProductName { get; init; } = String.Empty;
        public int InitialInventory { get; init; } = 0;
        public int FinalInventory { get; init; } = 0;
        public int Difference { get; init; } = 0;
        public int DailyMove { get; init; } = 0;
        public int Entries { get; init; } = 0;
        public int Courtesy { get; init; } = 0;
        public int Damaged { get; init; } = 0;
        public int Remains { get; init; } = 0;
    }
}

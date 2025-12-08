namespace CookManagement.VSA.Features.Users.GetUserRecords
{
    public sealed record RecordsPaginatedResponse
    {
        public RecordsPaginatedResponse()
        {
            UserRecords = new List<UserRecordsResponse>();
        }

        public List<UserRecordsResponse> UserRecords { get; init; }
        public int RecordsCount { get; init; }
    }
}

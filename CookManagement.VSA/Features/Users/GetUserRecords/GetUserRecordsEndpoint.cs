namespace CookManagement.VSA.Features.Users.GetUserRecords
{
    public static class GetUserRecordsEndpoint
    {
        public static RouteGroupBuilder MapGetUserRecordsEndpoint(this RouteGroupBuilder groupBuilder)
        {
            groupBuilder.MapGet("records",
                async (GetUserRecordsHandler handler, string userName,
                    DateTime requestedDate, string timeZoneId, int page = 1, int pageSize = 12) =>
                {
                    var results = await handler.HandleAsync(userName, requestedDate, timeZoneId, page, pageSize);
                    return Results.Ok(results);
                })
                .Produces<RecordsPaginatedResponse>()
                .RequireAuthorization("AdminOnly");

            return groupBuilder;
        }
    }
}

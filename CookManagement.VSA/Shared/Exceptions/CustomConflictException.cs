using Microsoft.AspNetCore.Mvc;

namespace CookManagement.VSA.Shared.Exceptions
{
    public class CustomConflictException : CustomBaseException
    {
        public CustomConflictException(string message) : base(message)
        {
        }

        public override int StatusCode { get; } = StatusCodes.Status409Conflict;

        public override ProblemDetails GetProblemDetails()
        {
            return new ProblemDetails
            {
                Title = "Resource Conflict",
                Detail = $"{GetType().Name}: {Message}",
                Status = StatusCode,
            };
        }

    }
}

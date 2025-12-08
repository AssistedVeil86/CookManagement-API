using Microsoft.AspNetCore.Mvc;

namespace CookManagement.VSA.Shared.Exceptions
{
    public class CustomInvalidOperationException : CustomBaseException
    {
        public CustomInvalidOperationException(string message) : base(message)
        {
        }

        public override int StatusCode { get; } = StatusCodes.Status400BadRequest;

        public override ProblemDetails GetProblemDetails()
        {
            return new ProblemDetails()
            {
                Title = "Invalid Operation Attempt",
                Detail = $"{GetType().Name} - {Message}",
                Status = StatusCode,
            };
        }

    }
}

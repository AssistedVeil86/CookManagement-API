using Microsoft.AspNetCore.Mvc;

namespace CookManagement.VSA.Shared.Exceptions
{
    public class CustomInvalidAuthException : CustomBaseException
    {
        public CustomInvalidAuthException(string message) : base(message)
        {
        }

        public override int StatusCode { get; } = StatusCodes.Status401Unauthorized;

        public override ProblemDetails GetProblemDetails()
        {
            return new ProblemDetails
            {
                Title = "Unauthorized Access",
                Detail = $"{GetType().Name}: {Message}",
                Status = StatusCode,
            };
        }

    }
}

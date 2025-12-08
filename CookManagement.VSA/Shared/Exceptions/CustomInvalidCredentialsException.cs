using Microsoft.AspNetCore.Mvc;

namespace CookManagement.VSA.Shared.Exceptions
{
    public class CustomInvalidCredentialsException : CustomBaseException
    {
        public CustomInvalidCredentialsException(string message) : base(message)
        {
        }

        public override int StatusCode { get; } = StatusCodes.Status400BadRequest;

        public override ProblemDetails GetProblemDetails()
        {
            return new ProblemDetails()
            {
                Title = "Invalid Auth Credentials",
                Detail = $"{GetType().Name} - {Message}",
                Status = StatusCode,
            };
        }

    }
}

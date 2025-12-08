using Microsoft.AspNetCore.Mvc;

namespace CookManagement.VSA.Shared.Exceptions
{
    public class CustomNotFoundException : CustomBaseException
    {
        public CustomNotFoundException(string message) : base(message)
        {
        }

        public override int StatusCode { get; } = StatusCodes.Status404NotFound;

        public override ProblemDetails GetProblemDetails()
        {
            return new ProblemDetails
            {
                Title = "Resource Not Found",
                Detail = $"{GetType().Name}: {Message}",
                Status = StatusCode,
            };
        }

    }
}

using Microsoft.AspNetCore.Mvc;

namespace CookManagement.VSA.Shared.Exceptions
{
    public abstract class CustomBaseException : Exception
    {
        public CustomBaseException(string message) : base(message)
        {
        }

        public abstract int StatusCode { get; }

        public virtual ProblemDetails GetProblemDetails()
        {
            return new ProblemDetails()
            {
                Title = "Error",
                Detail = $"{GetType().Name} - {Message}",
                Status = StatusCode,
            };
        }

    }
}


using CookManagement.VSA.Shared.Exceptions;

namespace CookManagement.VSA.Infrastructure.Filters
{
    public class ExceptionFilter : IEndpointFilter
    {
        private readonly ILogger<ExceptionFilter> _logger;

        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            _logger = logger;
        }

        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            try
            {
                return await next(context);
            }
            catch (CustomBaseException e)
            {
                var endpoint = context.HttpContext.GetEndpoint();
                var name = endpoint is RouteEndpoint routeEndpoint ? routeEndpoint.RoutePattern.RawText : "Unknown Route";

                _logger.LogError(e, "Uncaught Exception in Endpoint {EndpointName}", name);

                var details = e.GetProblemDetails();
                var statusCode = e.StatusCode;

                return Results.Json(details, contentType: "application/problem+json", statusCode: statusCode);
            }
        }
    }
}

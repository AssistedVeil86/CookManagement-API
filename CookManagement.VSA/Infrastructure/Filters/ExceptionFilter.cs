
using CookManagement.VSA.Domain.Exceptions;

namespace CookManagement.VSA.Infrastructure.Filters
{
    public class ExceptionFilter(ILogger<ExceptionFilter> logger) : IEndpointFilter
    {
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

                logger.LogError(e, "Uncaught Exception in Endpoint {EndpointName}", name);

                var details = e.GetProblemDetails();
                var statusCode = e.StatusCode;

                return Results.Json(details, contentType: "application/problem+json", statusCode: statusCode);
            }
        }
    }
}

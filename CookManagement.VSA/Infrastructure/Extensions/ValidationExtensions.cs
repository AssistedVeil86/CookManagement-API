using CookManagement.VSA.Infrastructure.Filters;
using FluentValidation;

namespace CookManagement.VSA.Infrastructure.Extensions
{
    public static class ValidationExtensions
    {
        public static IServiceCollection RegisterValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<Program>();

            return services;
        }

        public static RouteHandlerBuilder WithRequestValidation<TRequest>(this RouteHandlerBuilder builder)
        {
            return builder.AddEndpointFilter<ValidationFilter<TRequest>>()
                .ProducesValidationProblem();
        }
    }
}

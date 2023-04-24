using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using OrionTekTest.Domain.Validators;

namespace OrionTekTest.Configurations.Validators
{
    public static class FluentValidatorExtension
    {
        public static void AddValidators(this IServiceCollection services)
        {
            services.AddFluentValidation(options =>
            {
                // Validate child properties and root collection elements
                options.ImplicitlyValidateChildProperties = true;
                options.ImplicitlyValidateRootCollectionElements = true;
                // Automatic registration of validators in assembly
                options.RegisterValidatorsFromAssemblyContaining<CustomerValidator>();
            });
        }
    }
}

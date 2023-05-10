using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using OrionTekTest.Domain.Entities;
using OrionTekTest.Domain.Validators;
using System;

namespace OrionTekTest.Configurations.Validators
{
    public static class FluentValidatorExtension
    {
        public static void AddValidators(this IServiceCollection services)
        {
            services.AddFluentValidationClientsideAdapters();

            services.AddScoped<IValidator<Customer>, CustomerValidator>();

            services.AddScoped<IValidator<Address>, AddressValidator>();
        }
    }
}

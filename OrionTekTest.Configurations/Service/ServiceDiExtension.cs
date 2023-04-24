using Microsoft.Extensions.DependencyInjection;
using OrionTekTest.Application.Services;
using OrionTekTest.Domain.Contracts;
using OrionTekTest.Domain.Entities;

namespace OrionTekTest.Configurations.Service
{
    public static class ServiceDiExtension
    {
        public static void AddService(this IServiceCollection services)
        {
            services.AddScoped(typeof(IService<Customer>), typeof(CustomerService));
        }
    }
}

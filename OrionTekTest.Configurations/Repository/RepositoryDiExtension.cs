using Microsoft.Extensions.DependencyInjection;
using OrionTekTest.Data;
using OrionTekTest.Domain.Contracts;
using OrionTekTest.Domain.Entities;

namespace OrionTekTest.Configurations.Repository
{
    public static class RepositoryDiExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<Customer>), typeof(CustomerRepository));
            services.AddScoped(typeof(IRepository<Address>), typeof(Repository<Address>));
        }
    }
}

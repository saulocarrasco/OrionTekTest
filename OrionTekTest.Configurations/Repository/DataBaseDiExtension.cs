using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrionTekTest.Data;

namespace OrionTekTest.Configurations.Repository
{
    public static class DataBaseDiExtension
    {
        public static void AddCustomerDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var sqlDataConnectionString = configuration.GetConnectionString("SqlDataConnectionString");

            services.AddDbContext<CustomersDbContext>(options =>
            {
                options.UseSqlServer(sqlDataConnectionString, m => m.MigrationsAssembly("OrionTekTest.Data"));
            });
        }
    }
}

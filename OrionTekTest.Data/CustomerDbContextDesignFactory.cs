using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace OrionTekTest.Data
{
    public class CustomerDbContextDesignFactory : IDesignTimeDbContextFactory<CustomersDbContext>
    {
        public CustomersDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            var builder = new DbContextOptionsBuilder<CustomersDbContext>();


            var connectionString = configuration.GetConnectionString("SqlDataConnectionString");
            builder.UseSqlServer(connectionString);

            return new CustomersDbContext(builder.Options);
        }
    }
}

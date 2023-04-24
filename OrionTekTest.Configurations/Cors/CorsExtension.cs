using Microsoft.Extensions.DependencyInjection;

namespace OrionTekTest.Configurations.Cors
{
    public static class CorsExtension
    {
        public static void AddCorsConfiguration(this IServiceCollection services, string policyName)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(policyName,
                builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });
        }
    }
}

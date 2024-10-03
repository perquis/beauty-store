using BeautyStore.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BeautyStore.Infrastructure.Extensions
{
    public static class ServiceExtensionCollection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("PostgresConnection");

            services.AddDbContext<BeautyStoreDbContext>(options =>
                options.UseNpgsql(connectionString));

            return services;
        }
    }
}

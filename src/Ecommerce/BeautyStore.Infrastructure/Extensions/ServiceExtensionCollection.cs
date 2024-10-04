using BeautyStore.Domain.Interfaces;
using BeautyStore.Infrastructure.Persistance;
using BeautyStore.Infrastructure.Repositories;
using BeautyStore.Infrastructure.Seeders;
using Microsoft.AspNetCore.Identity;
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

            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
				.AddEntityFrameworkStores<BeautyStoreDbContext>();

            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<UserRolesSeeder>();
            services.AddScoped<SuperUsersSeeder>();

            return services;
        }
    }
}

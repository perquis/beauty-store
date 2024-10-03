using AutoMapper;
using BeautyStore.Application.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace BeautyStore.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped(services => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ProductMappingProfile());
            }).CreateMapper());
        }
    }
}

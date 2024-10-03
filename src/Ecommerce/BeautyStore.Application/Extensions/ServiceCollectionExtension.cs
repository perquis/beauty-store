using AutoMapper;
using BeautyStore.Application.Mappings;
using BeautyStore.Application.Product.Commands.CreateProduct;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BeautyStore.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped(services => new MapperConfiguration(cfg =>
            {
                var service = services.CreateScope().ServiceProvider;

                cfg.AddProfile(new ProductMappingProfile());
            }).CreateMapper());

            services.AddMediatR(typeof(CreateProductCommand));

            services.AddValidatorsFromAssemblyContaining<CreateProductCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }
}

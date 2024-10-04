using AutoMapper;
using BeautyStore.Application.Mappings;
using BeautyStore.Application.Product.Commands.CreateProduct;
using BeautyStore.Application.User;
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
            services.AddScoped<IUserSession, UserSession>();

            services.AddScoped(services => new MapperConfiguration(cfg =>
            {
                var service = services.CreateScope().ServiceProvider;
                var userSession = service.GetRequiredService<IUserSession>();

                cfg.AddProfile(new ProductMappingProfile(userSession));
            }).CreateMapper());

            services.AddMediatR(typeof(CreateProductCommand));

            services.AddValidatorsFromAssemblyContaining<CreateProductCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }
}

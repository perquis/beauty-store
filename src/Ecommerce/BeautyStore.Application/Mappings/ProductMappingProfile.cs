using AutoMapper;
using BeautyStore.Application.Product;

namespace BeautyStore.Application.Mappings
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Domain.Entities.Product, ProductDto>();
            CreateMap<ProductDto, Domain.Entities.Product>();
        }
    }
}

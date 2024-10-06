using AutoMapper;
using BeautyStore.Application.Product;
using BeautyStore.Application.User;

namespace BeautyStore.Application.Mappings
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile(IUserSession session)
        {
            CreateMap<Domain.Entities.Product, ProductDto>();

            CreateMap<ProductDto, Domain.Entities.Product>()
                .ForMember(x => x.Images, opt => opt.Ignore());
        }
    }
}

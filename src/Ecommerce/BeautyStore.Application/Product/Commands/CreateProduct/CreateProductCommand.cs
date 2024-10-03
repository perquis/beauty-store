using MediatR;

namespace BeautyStore.Application.Product.Commands.CreateProduct
{
    public class CreateProductCommand : ProductDto, IRequest
    {
    }
}

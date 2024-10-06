using System.Net;
using BeautyStore.Domain.Interfaces;

namespace BeautyStore.Infrastructure.Repositories
{
    public class ProductImagesRepository : IProductImagesRepository
    {
        private readonly IProductRepository _productRepository;

        public ProductImagesRepository(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task CreateProductImagesAsync(Guid productId, string[] images)
        {
            var product = await _productRepository.GetProductByIdAsync(productId);

            if (product == null) {
                throw new HttpException(HttpStatusCode.NotFound, "Product not found");
            }

            product.Images!.AddRange(
                images.Select(image => new Domain.Entities.ProductImage 
                { 
                    Url = image, 
                    ProductId = productId
                }
             ));

            await _productRepository.UpdateProductAsync(product);
        }
    }
}

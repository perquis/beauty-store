using BeautyStore.Domain.Entities;
using BeautyStore.Domain.Interfaces;
using BeautyStore.Infrastructure.Persistance;

namespace BeautyStore.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly BeautyStoreDbContext _context;

        public ProductRepository(BeautyStoreDbContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task CreateProductAsync(Product product)
        {
            product.EncodeName();
            _context.Products.Add(product);

            await _context.SaveChangesAsync();
        }

        public Task UpdateProductAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProductAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}

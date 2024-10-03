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

        public async Task CreateProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        Task<Product> IProductRepository.DeleteProductAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Product>> IProductRepository.GetAllProductsAsync()
        {
            throw new NotImplementedException();
        }

        Task<Product> IProductRepository.GetProductByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<Product> IProductRepository.UpdateProductAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}

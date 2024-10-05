using System.Net;
using BeautyStore.Domain.Entities;
using BeautyStore.Domain.Interfaces;
using BeautyStore.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace BeautyStore.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly BeautyStoreDbContext _context;

        public ProductRepository(BeautyStoreDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }

        public async Task<Product> GetProductByIdAsync(Guid id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                throw new HttpException(HttpStatusCode.NotFound, "Product not found");
            }

            return product;
        }

        public async Task CreateProductAsync(Product product)
        {
            product.EncodeName();
            _context.Products.Add(product);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            var productToUpdate = await _context.Products.FirstOrDefaultAsync(p => p.Id == product.Id);

            if (productToUpdate == null) {
                throw new HttpException(HttpStatusCode.NotFound, "Product not found");
            }

            productToUpdate.Name = product.Name;
            productToUpdate.Description = product.Description;
            
            productToUpdate.Price = product.Price;
            productToUpdate.Stock = product.Stock;
            productToUpdate.Category = product.Category;

            productToUpdate.Currency = product.Currency;

            productToUpdate.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(Guid id)
        {
            var product = await GetProductByIdAsync(id);

            if (product == null) {
                throw new HttpException(HttpStatusCode.NotFound, "Product not found");
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}

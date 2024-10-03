using BeautyStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BeautyStore.Infrastructure.Persistance
{
    public class BeautyStoreDbContext : DbContext
    {
        private DbSet<Product> Products { get; set; } = default!;

        public BeautyStoreDbContext(DbContextOptions<BeautyStoreDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>().HasKey(p => p.Id);
            builder.Entity<Product>().HasMany(p => p.Images).WithOne(p => p.Product).HasForeignKey(i => i.ProductId);

            base.OnModelCreating(builder);
        }
    }
}

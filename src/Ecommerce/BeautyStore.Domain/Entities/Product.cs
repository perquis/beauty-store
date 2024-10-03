namespace BeautyStore.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }
        public string Description { get; set; } = default!;
        public string Currency { get; set; } = "USD";
        public int Stock { get; set; } = 0;
        public ProductCategory Category { get; set; }
        public List<ProductImage> Images { get; set; } = new List<ProductImage>();

        public void EncodedName() => Name.Replace(" ", "-").ToLower();
    }
}

namespace BeautyStore.Application.Product
{
    public class ProductDto
    {
        public Guid? Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }
        public string Description { get; set; } = default!;
        public string Currency { get; set; } = "USD";
        public int Stock { get; set; } = 0;
        public string Category { get; set; } = "Makeup";
        public string? EncodedName { get; set; } = default!;
    }
}

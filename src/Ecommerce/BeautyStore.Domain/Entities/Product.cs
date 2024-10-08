﻿namespace BeautyStore.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }
        public string Description { get; set; } = default!;
        public Currency Currency { get; set; } = Currency.USD;
        public int Stock { get; set; } = 0;
        public ProductCategory Category { get; set; }
        public List<ProductImage>? Images { get; set; } = new List<ProductImage>();
        public string? EncodedName { get; set; } = default!;

        public string? CreatedByUserId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public void EncodeName() => EncodedName = Name.Replace(" ", "-").ToLower();
    }
}

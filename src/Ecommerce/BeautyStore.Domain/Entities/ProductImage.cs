using System.Text.Encodings.Web;

namespace BeautyStore.Domain.Entities
{
    public class ProductImage
    {
        public int Id { get; set; }
        public string Url { get; set; } = default!;
        public Guid ProductId { get; set; } = default!;
        public Product Product { get; set; } = default!;
    }
}

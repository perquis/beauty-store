using FluentAssertions;
using Xunit;

namespace BeautyStore.Domain.Entities.Tests
{
    public class ProductTests
    {
        [Fact()]
        public void EncodeName_ShouldSetEncodedName()
        {
            var product = new Product()
            {
                Name = "Lipstick Limo",
                Price = 10.99m,
                Description = "A lipstick for your lips",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Currency = Currency.USD,
                Stock = 100,
                Category = ProductCategory.Makeup,
                Id = Guid.NewGuid()
            };

            product.EncodeName();

            product.EncodedName.Should().Be("lipstick-limo");
        }

        [Fact()]
        public void EncodeName_ShouldThrowException_WhenNameIsNull()
        {
            var product = new Product()
            {
                Price = 10.99m,
                Description = "A lipstick for your lips",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Currency = Currency.USD,
                Stock = 100,
                Category = ProductCategory.Makeup,
                Id = Guid.NewGuid()
            };

            Action action = () => product.EncodeName();

            action.Should().Throw<NullReferenceException>();
        }

        [Fact()]
        public void Images_ShouldBeInitialized_WhenItIsProvided()
        {
            var product = new Product()
            {
                Name = "Lipstick Limo",
                Price = 10.99m,
                Description = "A lipstick for your lips",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Currency = Currency.USD,
                Stock = 100,
                Category = ProductCategory.Makeup,
                Id = Guid.NewGuid(),
                Images = new List<ProductImage>()
                {
                    new ProductImage()
                    {
                        Url = "https://example.com/image.jpg"
                    }
                }
            };

            product.Images.Should().NotBeNull();
            product.Images.Should().HaveCount(1);
        }
    }
}
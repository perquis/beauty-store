using AutoMapper;
using BeautyStore.Application.Product;
using BeautyStore.Application.User;
using FluentAssertions;
using Moq;
using Xunit;

namespace BeautyStore.Application.Mappings.Tests
{
    public class ProductMappingProfileTests
    {
        [Fact()]
        public void MappingProfile_ShouldMapProductDtoToProduct()
        {
            var userSessionMock = new Mock<IUserSession>();

            userSessionMock.Setup(x => x.GetSession()).Returns(new GetUserSession()
            {
                Id = "1",
                Email = "example@domain.com",
                Role = new[] { "Admin", "User" }
            });

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ProductMappingProfile(userSessionMock.Object));
            });

            var mapper = configuration.CreateMapper();

            var dto = new ProductDto
            {
                Id = Guid.NewGuid(),
                Name = "Product name",
                Price = 10,
                Description = "Description",
                Currency = "USD",
                Stock = 10,
                Category = "Makeup",
                Images = "https://example.com/assets/test-image.png"
            };

            var result = mapper.Map<Domain.Entities.Product>(dto);

            result.Should().NotBeNull();
            result.Name.Should().Be(dto.Name);
            result.Price.Should().Be(dto.Price);
            result.Description.Should().Be(dto.Description);
            result.Stock.Should().Be(dto.Stock);
        }
    }
}
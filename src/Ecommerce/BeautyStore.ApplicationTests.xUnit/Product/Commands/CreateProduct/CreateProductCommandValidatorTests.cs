using FluentValidation.TestHelper;
using Xunit;

namespace BeautyStore.Application.Product.Commands.CreateProduct.Tests
{
    public class CreateProductCommandValidatorTests
    {
        [Fact()]
        public void Validate_WithValidCommand_ShouldNotHaveValidationError()
        {
            var validator = new CreateProductCommandValidator();
            var command = new CreateProductCommand
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

            var result = validator.TestValidate(command);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact()]
        public void Validate_WithInvalidCommand_ShouldHaveValidationErrors()
        {
            var validator = new CreateProductCommandValidator();
            var command = new CreateProductCommand
            {
                Id = Guid.NewGuid(),
                Name = "",
                Price = 0,
                Description = "",
                Currency = "",
                Stock = 0,
                Category = "",
                Images = ""
            };

            var result = validator.TestValidate(command);

            result.ShouldHaveValidationErrorFor(x => x.Name);
            result.ShouldHaveValidationErrorFor(x => x.Price);
            result.ShouldHaveValidationErrorFor(x => x.Description);
            result.ShouldHaveValidationErrorFor(x => x.Currency);
            result.ShouldHaveValidationErrorFor(x => x.Stock);
            result.ShouldHaveValidationErrorFor(x => x.Category);
            result.ShouldHaveValidationErrorFor(x => x.Images);
        }
    }
}
using BeautyStore.Domain.Entities;
using FluentValidation;

namespace BeautyStore.Application.Product.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(10)
                .MaximumLength(64);

            RuleFor(x => x.Description)
                .NotEmpty()
                .MinimumLength(10)
                .MaximumLength(256);

            RuleFor(x => x.Price)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.Stock)
                .NotEmpty();

            RuleFor(x => x.Category)
                .NotEmpty()
                .IsEnumName(typeof(ProductCategory));

            RuleFor(x => x.Currency)
                .NotEmpty()
                .IsEnumName(typeof(Currency));

            RuleFor(x => x.Images)
                .NotEmpty()
                .Matches(@"^;?https://")
                .WithMessage("The links should be with prefix 'https://' or ';https:// if you want to add more than one link.'");
        }
    }
}

using eCommerce.Products.Core.Products.Catalag.Models;
using FluentValidation;

namespace eCommerce.Products.Core.Products.Catalag.Validators
{
    public abstract class ProductBaseValidator<T> : AbstractValidator<T> where T : ProductBase
    {
        public ProductBaseValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Field Name is required.")
            .NotNull().WithMessage("Field Name can not be null.")
            .MaximumLength(100)
            .MinimumLength(5);

            RuleFor(x => x.BillingType).IsInEnum().WithMessage("El mensaje ");
        }
    }
}

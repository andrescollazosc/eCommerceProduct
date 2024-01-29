using eCommerce.Products.Core.Products.Catalag.Models;
using FluentValidation;

namespace eCommerce.Products.Core.Products.Catalag.Validators;

public class ProductDeviceValidator : ProductBaseValidator<ProductDevice>
{
    public ProductDeviceValidator()
    {
        When(x => x.Category == Enums.Category.DeviceMobile || x.Category == Enums.Category.DeviceTable, () =>
        {
            RuleFor(x => x.Details.Brand).NotEmpty().WithMessage("The brand cannot be empty using this category.");
            RuleFor(x => x.Details.Model).NotEmpty().WithMessage("The model cannot be empty using this category.");
        });
    }
}

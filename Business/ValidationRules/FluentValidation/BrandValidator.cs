using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation;

public class BrandValidator:AbstractValidator<Brand>
{
    public BrandValidator()
    {
        RuleFor(brand => brand.BrandName).NotEmpty().WithMessage("Brand name is required.");
    }
}
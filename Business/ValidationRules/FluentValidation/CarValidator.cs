using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(car => car.Id).Empty();
            RuleFor(car => car.ColorId).NotEmpty().WithMessage("Enter color id");
            RuleFor(car => car.BrandId).NotEmpty().WithMessage("Enter brand id");
            RuleFor(car => car.CarName).NotEmpty().WithMessage("Enter car name");
            RuleFor(car => car.CarName).MinimumLength(2);
            RuleFor(car => car.DailyPrice).NotEmpty().WithMessage("Enter daily price");
            RuleFor(car => car.DailyPrice).GreaterThan(500);
            RuleFor(car => car.ModelYear).NotEmpty().WithMessage("Enter model year");
        }
    }
}

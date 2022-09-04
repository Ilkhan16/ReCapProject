using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarImageValidator:AbstractValidator<CarImage>
    {
        public CarImageValidator()
        {
            RuleFor(image => image.CarId).NotEmpty().WithMessage("Enter Car id");
            RuleFor(image => image.Date).NotEmpty().WithMessage("Enter date");
        }
    }
}
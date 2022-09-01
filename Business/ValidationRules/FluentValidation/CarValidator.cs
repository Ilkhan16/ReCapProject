using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilites.Results.Abstract;
using Entities.Concrete;
using FluentValidation;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
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

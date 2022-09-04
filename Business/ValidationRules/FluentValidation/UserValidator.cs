using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.EMail).NotEmpty().WithMessage("Email address is required").
                EmailAddress().WithMessage("A valid email is required");
            RuleFor(user => user.FirstName).NotEmpty().WithMessage("First name is required");
            RuleFor(user => user.LastName).NotEmpty().WithMessage("Last name is required");
            RuleFor(user => user.Password).NotEmpty().WithMessage("Password is required").
                MinimumLength(5).WithMessage("Password min 5 char");
        }
    }
}

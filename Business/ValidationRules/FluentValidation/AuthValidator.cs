using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation;

public class AuthValidator : AbstractValidator<User>
{
    public AuthValidator()
    {
        RuleFor(user => user.Email).NotEmpty().WithMessage("Email address is required").EmailAddress().WithMessage("A valid email is required");
        RuleFor(user => user.FirstName).NotEmpty().WithMessage("First name is required");
        RuleFor(user => user.LastName).NotEmpty().WithMessage("Last name is required");
    }
}
using ServiceModel.Dto;
using FluentValidation;

namespace IssueTracker.Validators
{
    public class RegisterUserRequestValidator:AbstractValidator<RegisterUserRequest>
    {
        public RegisterUserRequestValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty().MaximumLength(20).Equal(x=>x.ConfirmPassword);
            RuleFor(x=>x.ConfirmPassword).NotEmpty().MaximumLength(20).Equal(x=>x.Password);
        }
    }
}

using FluentValidation;
using ServiceModel.Type;

namespace IssueTracker.Validators
{
    public class UserValidator<T>:AbstractValidator<T> where T:User
    {
        public UserValidator()
        {
            RuleFor(x=>x.Username).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Password).NotEmpty().MaximumLength(20);
        }
    }
}

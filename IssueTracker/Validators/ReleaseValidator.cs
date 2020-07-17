using FluentValidation;
using ServiceModel.Type;

namespace IssueTracker.Validators
{
    public class ReleaseValidator<T> : AbstractValidator<T> where T : Release
    {
        public ReleaseValidator()
        {
            RuleSet("Required", () =>
            {
                RuleFor(release => release.ReleaseName).NotEmpty().MaximumLength(20);
                RuleFor(release => release.SprintStatusId).NotEmpty().NotEqual(-1);
                RuleFor(x => x.StartDate).NotEmpty().LessThan(x => x.EndDate);
                RuleFor(x => x.EndDate).NotEmpty().GreaterThan(x => x.StartDate);
            });
        }
    }
}

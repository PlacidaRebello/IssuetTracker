using FluentValidation;
using ServiceModel.Dto;

namespace IssueTracker.Validators
{
    public class EditReleaseRequestValidator:ReleaseValidator<EditReleaseRequest>
    {
        public EditReleaseRequestValidator()
        {
            RuleFor(x=>x.ReleaseId).NotEmpty().NotEqual(0);
        }
    }
}

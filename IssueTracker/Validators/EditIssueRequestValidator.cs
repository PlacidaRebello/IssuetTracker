using ServiceModel.Dto;
using FluentValidation;

namespace IssueTracker.Validators
{
    public class EditIssueRequestValidator:IssueValidator<EditIssueRequest>
    {
        public EditIssueRequestValidator()
        {
            RuleFor(x=>x.IssueId).NotEmpty().NotEqual(-1);
        }
    }
}

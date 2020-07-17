using FluentValidation;
using ServiceModel.Dto;

namespace IssueTracker.Validators
{
    public class EditSprintRequestValidator: SprintsValidator<EditSprintRequest>
    {
        public EditSprintRequestValidator()
        {
            RuleFor(x => x.SprintId).NotEmpty().NotEqual(0);
        }
    }
}

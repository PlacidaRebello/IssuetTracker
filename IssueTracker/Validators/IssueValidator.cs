using DataAccess.DataModels;
using FluentValidation;
using ServiceModel.Type;

namespace IssueTracker.Validators
{
    public class IssueValidator<T>:AbstractValidator<T> where T:Issue
    {
        public IssueValidator()
        {
            RuleSet("Required", () => {
                RuleFor(x => x.Subject).NotEmpty().MaximumLength(20);
                RuleFor(x => x.Description).NotEmpty().MaximumLength(100);
                RuleFor(x => x.Tags).NotEmpty().MaximumLength(5);
                RuleFor(x => x.AssignedTo).NotEmpty().MaximumLength(100);
                RuleFor(x => x.IssueStatusId).NotEqual(0).NotEqual(-1);
                RuleFor(x => x.IssueTypeId).InclusiveBetween(1,3);
                RuleFor(x => x.SprintId).NotEqual(0).NotEqual(-1);
                RuleFor(x=>x.Order).NotNull();
                RuleFor(x => x.Attachment).NotEmpty().MaximumLength(20).MinimumLength(3).When(x=>x.IssueTypeId==(int)IssueType.Bug);
                RuleFor(x => x.Reporter).NotEmpty().NotNull().MaximumLength(50).When(x => x.IssueTypeId == (int)IssueType.Bug);
                RuleFor(x => x.Enviroment).NotEmpty().MaximumLength(20).MinimumLength(3).When(x => x.IssueTypeId == (int)IssueType.Bug);
                RuleFor(x => x.Browser).NotEmpty().MaximumLength(10).MinimumLength(3).When(x => x.IssueTypeId == (int)IssueType.Bug);
                RuleFor(x => x.AcceptanceCriteria).NotEmpty().MinimumLength(3).MaximumLength(20).When(x => x.IssueTypeId == (int)IssueType.Story);
                RuleFor(x => x.Epic).NotEmpty().NotEqual(-1).When(x => x.IssueTypeId == (int)IssueType.Story);
                RuleFor(x => x.StoryPoints).NotEmpty().NotEqual(0).ScalePrecision(2, 4).When(x => x.IssueTypeId == (int)IssueType.Story);
                RuleFor(x => x.UAT).NotNull().NotEmpty().When(x => x.IssueTypeId == (int)IssueType.Story);
                RuleFor(x => x.TimeTracking).NotEmpty().When(x => x.IssueTypeId == (int)IssueType.Task);
            });
        }
    }
}

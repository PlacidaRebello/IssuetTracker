using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using ServiceModel.Type;

namespace IssueTracker.Validators
{
    public class SprintsValidator<T>:AbstractValidator<T> where T:Sprint
    {
        public SprintsValidator()
        {
            RuleSet("Required", () => {
                RuleFor(x => x.SprintName).NotEmpty().MaximumLength(20);
                RuleFor(x => x.SprintPoints).NotEqual(0).ScalePrecision(2,4);
                RuleFor(x => x.SprintStatusId).NotEqual(0).NotEqual(-1);
                RuleFor(x => x.ReleaseId).NotEqual(0);
                RuleFor(x => x.StartDate).NotEmpty().LessThan(x=>x.EndDate);
                RuleFor(x => x.EndDate).NotEmpty().GreaterThan(x=>x.StartDate);
            });
        }
    }
}

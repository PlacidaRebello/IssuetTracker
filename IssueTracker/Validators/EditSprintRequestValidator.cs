using FluentValidation;
using ServiceModel.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IssueTracker.Validators
{
    public class EditSprintRequestValidator: SprintsValidator<EditSprintRequest>
    {
        public EditSprintRequestValidator()
        {
            RuleFor(x => x.SprintId).NotEqual(0);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using ServiceModel.Dto;

namespace IssueTracker.Validators
{
    public class CreateSprintRequestValidator:SprintsValidator<CreateSprintRequest>
    {
        public CreateSprintRequestValidator()
        {           
        }
    }
}

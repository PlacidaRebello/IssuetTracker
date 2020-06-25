using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using ServiceModel.Dto;

namespace IssueTracker.Validators
{
    public class ReleaseValidator:AbstractValidator<CreateReleaseRequest>
    {
        public ReleaseValidator()
        {
            RuleFor(release=>release.ReleaseName).NotEmpty();
            RuleFor(release => release.SprintStatusId).NotEmpty();

        }
    }
}

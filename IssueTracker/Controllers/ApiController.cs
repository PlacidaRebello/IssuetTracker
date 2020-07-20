using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceModel.Dto;

namespace IssueTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        //public SuccessResponse Validate(ValidationResult result)
        //{
        //    foreach (var failure in result.Errors)
        //    {
        //        return new SuccessResponse
        //        {
        //            Message = failure.PropertyName + " failed validation." + failure.ErrorMessage
        //        };
        //    }
        //}
    }
}
using AutoMapper;
using BussinessLogic.Interfaces;
using DataAccess.Models;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceModel.Dto;
using System.Collections.Generic;

namespace IssueTracker.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReleasesController : ControllerBase
    {
        private readonly IReleaseLogic _releaseLogic;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateReleaseRequest> _createValidator;
        private readonly IValidator<EditReleaseRequest> _editValidator;
        public ReleasesController(IReleaseLogic releaseLogic, IMapper mapper, IValidator<CreateReleaseRequest> createValidator, IValidator<EditReleaseRequest> editValidator)
        {
            _releaseLogic = releaseLogic;
            _mapper = mapper;
            _createValidator = createValidator;
            _editValidator = editValidator;
        }

        [HttpGet]
        public IEnumerable<GetReleaseData> GetReleases()
        {
            List<Release> release = _releaseLogic.GetReleaseList();
            List<GetReleaseData> releaseList = _mapper.Map<List<Release>, List<GetReleaseData>>(release);
            return releaseList;
        }

        [HttpGet("{id}")]
        public GetReleaseData GetRelease(int id)
        {
            var release = _releaseLogic.GetRelease(id);
            GetReleaseData getRelease = _mapper.Map<Release, GetReleaseData>(release);
            return getRelease;
        }

        [HttpPut]
        public SuccessResponse PutRelease(EditReleaseRequest release)
        {
            var result = _editValidator.Validate(release, ruleSet: "*");
            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    return new SuccessResponse
                    {
                        Message = failure.PropertyName + " failed validation." + failure.ErrorMessage
                    };
                }
            }
            var newRelease = _mapper.Map<Release>(release);
            _releaseLogic.EditRelease(newRelease);
            return new SuccessResponse
            {
                Message = "Release Edited Succesfully"
            };
        }

        [HttpPost]
        public SuccessResponse PostRelease(CreateReleaseRequest release)
        {
            var result = _createValidator.Validate(release, ruleSet: "Required");
            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    return new SuccessResponse
                    {
                        Message =failure.PropertyName + " failed validation."+failure.ErrorMessage
                    };
                }
            }    

            var newRelease = _mapper.Map<Release>(release);
            var releaseId = _releaseLogic.CreateRelease(newRelease);
            return new SuccessResponse
            {
                Id = releaseId,
                Message = "Release Created Successfully"
            };
            
        }

        [HttpDelete("{id}")]
        public SuccessResponse DeleteRelease(int id)
        {
            _releaseLogic.RemoveRelease(id);
            return new SuccessResponse
            {
                Id = id,
                Message = "Release Deleted Succesfully"
            };
        }

        [HttpGet]
        [Route("ReleaseList")]
        public IEnumerable<GetReleaseList> GetListOfReleases()
        {
            List<Release> release = _releaseLogic.GetReleaseList();
            List<GetReleaseList> releaseList = _mapper.Map<List<Release>, List<GetReleaseList>>(release);
            return releaseList;
        }
    }
}

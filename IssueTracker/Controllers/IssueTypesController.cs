using AutoMapper;
using BussinessLogic.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceModel.Dto;
using System;
using System.Collections.Generic;

namespace IssueTracker.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class IssueTypesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IIssueTypeLogic _issueTypeLogic;
        public IssueTypesController(IMapper mapper, IIssueTypeLogic issueTypeLogic)
        {
            _mapper = mapper;
            _issueTypeLogic = issueTypeLogic;
        }

        [HttpGet]
        public IEnumerable<GetIssueTypeData> GetIssueType()
        {
            List<IssueType> issueType = _issueTypeLogic.GetIssueTypeList();
            List<GetIssueTypeData> issueTypeList = _mapper.Map<List<IssueType>, List<GetIssueTypeData>>(issueType);
            return issueTypeList;
        }

        [HttpGet("{id}")]
        public GetIssueTypeData GetIssueType(int id)
        {
            var issueType = _issueTypeLogic.GetIssueType(id);
            GetIssueTypeData issueTypeData = _mapper.Map<IssueType, GetIssueTypeData>(issueType);
            return issueTypeData;
        }

        [HttpPut]
        public SuccessResponse PutIssueType(EditIssueTypeRequest issueType)
        {
            var newIssueType = _mapper.Map<IssueType>(issueType);
            _issueTypeLogic.EditIssueType(newIssueType);
            return new SuccessResponse
            {
                Id = newIssueType.IssueTypeId,
                Message = "Edited Successfully"
            };
        }

        [HttpPost]
        public SuccessResponse PostIssueType(CreateIssueTypeRequest issueType)
        {
            var newIssueType = _mapper.Map<IssueType>(issueType);
            newIssueType.CreatedDate = DateTime.Now;
            var issueTypeId = _issueTypeLogic.CreateIssueType(newIssueType);
            return new SuccessResponse
            {
                Id = issueTypeId,
                Message = "IssueType Created Successfully"
            };
        }

        [HttpDelete("{id}")]
        public SuccessResponse DeleteIssueType(int id)
        {
            _issueTypeLogic.RemoveIssueType(id);
            return new SuccessResponse
            {
                Id = id,
                Message = "Deleted Successfully"
            };
        }
    }
}

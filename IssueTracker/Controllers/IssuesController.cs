using AutoMapper;
using BussinessLogic.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceModel.Dto;
using System.Collections.Generic;

namespace IssueTracker.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class IssuesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IIssuesLogic _issuesLogic;
        public IssuesController(IMapper mapper, IIssuesLogic issuesLogic)
        {
            _mapper = mapper;
            _issuesLogic = issuesLogic;
        }

        [HttpGet]
        public IEnumerable<GetIssueData> GetIssueList()
        {
            List<Issue> issues = _issuesLogic.GetIssueList();
            List<GetIssueData> issueList = _mapper.Map<List<Issue>, List<GetIssueData>>(issues);
            return issueList;
        }

        [HttpGet("{id}")]
        public GetIssueData GetIssue(int id)
        {
            var issue = _issuesLogic.GetIssue(id);
            GetIssueData getIssue = _mapper.Map<Issue, GetIssueData>(issue);
            return getIssue;
        }

        [HttpPut]
        public CreateResponse PutIssue(EditIssueRequest issue)
        {
            var newIssue = _mapper.Map<Issue>(issue);
            newIssue.IssueStatus = new IssueStatus { StatusName = issue.IssueStatus };
            _issuesLogic.EditIssue(newIssue);
            return new CreateResponse
            {
                Message = "Edited Succesfully"
            };
        }

        [HttpPost]
        public CreateResponse PostIssue(CreateIssueRequest issue)
        {
            var newIssue = _mapper.Map<Issue>(issue);
            newIssue.IssueStatus = new IssueStatus { StatusName = issue.IssueStatus };
            var issueId = _issuesLogic.CreateIssue(newIssue);
            return new CreateResponse
            {
                Id = issueId,
                Message = "Issue Created Successfully"
            };
        }

        [HttpDelete("{id}")]
        public CreateResponse DeleteIssue(int id)
        {
            _issuesLogic.RemoveIssue(id);
            return new CreateResponse
            {
                Id = id,
                Message = "Deleted Succesfully"
            };
        }
    }
}

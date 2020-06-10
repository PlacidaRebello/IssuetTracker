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
        public SuccessResponse PutIssue(EditIssueRequest issue)
        {
            var newIssue = _mapper.Map<Issue>(issue);
            _issuesLogic.EditIssue(newIssue);
            return new SuccessResponse
            {
                Message = "Edited Succesfully"
            };
        }

        [HttpPost]
        public SuccessResponse PostIssue(CreateIssueRequest issue)
        {
            var newIssue = _mapper.Map<Issue>(issue);
            var issueId = _issuesLogic.CreateIssue(newIssue);

            return new SuccessResponse
            {
                Id = issueId,
                Message = "Issue Created Successfully"
            };
        }

        [HttpDelete("{id}")]
        public SuccessResponse DeleteIssue(int id)
        {
            _issuesLogic.RemoveIssue(id);
            return new SuccessResponse
            {
                Id = id,
                Message = "Deleted Succesfully"
            };
        }

        [HttpPut]
        [Route("DragDropIssue")]
        public SuccessResponse DragIssue(DragDropIssueRequest dragDropIssue)
        {
            _issuesLogic.DragDropIssues(dragDropIssue.PrevItem,dragDropIssue.PrevItemId,dragDropIssue.NextItemId,
                dragDropIssue.CurrentItemIndex,dragDropIssue.IssueStatus, dragDropIssue.IssueId);
            return new SuccessResponse
            {
                Message = "Succesfully"
            };
        }

        //[HttpGet]
        //[Route("Points")]
        //public int[] GetPoints() {
        //    int[] a = { 20, 40, 40 };
        //    return a;
        //}

    }
}

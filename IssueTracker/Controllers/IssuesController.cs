using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceModel.Dto;
using AutoMapper;
using DataAccess.Models;
using BussinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace IssueTracker.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class IssuesController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IIssuesLogic _issuesLogic;
        public IssuesController(DataContext context, IMapper mapper, IIssuesLogic issuesLogic)
        {
            _context = context;
            _mapper = mapper;
            _issuesLogic = issuesLogic;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Issue>>> GetIssues()
        {
            return await _context.Issues.ToListAsync();
        }

        [HttpGet("{id}")]
        public GetIssueData GetIssue(int id)
        {
            var issue = _issuesLogic.GetIssue(id);
            GetIssueData getIssue = _mapper.Map<Issue, GetIssueData>(issue);
            return getIssue;
        }

        [HttpPut("{id}")]
        public CreateResponse PutIssue(EditIssueRequest issue)
        {
            var newIssue = _mapper.Map<Issue>(issue);
            newIssue.Status = new Status { StatusName = issue.Status };
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
            newIssue.Status = new Status { StatusName = issue.Status };
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

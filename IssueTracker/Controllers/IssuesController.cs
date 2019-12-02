using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceModel.Dto;
using AutoMapper;
using DataAccess.Models;
using BussinessLogic.Interfaces;

namespace IssueTracker.Controllers
{
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

        // GET: api/Issues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Issue>>> GetIssues()
        {
            return await _context.Issues.ToListAsync();
        }

        // GET: api/Issues/5
        [HttpGet("{id}")]
        public  GetIssueResponse GetIssue(int id)
        {
            //var issue =_issuesLogic
            var issue= _issuesLogic.GetIssue(id);

            GetIssueResponse getIssue = _mapper.Map<Issue, GetIssueResponse>(issue);

            return getIssue;
           
            //return new GetIssueResponse
            //{
            //    IssueId = issue.IssueId,
            //    Subject = issue.Subject,
            //    Description = issue.Description,
            //    AssignedTo = issue.AssignedTo,
            //    Tags = issue.Tags,
            //    CreatedBy = issue.CreatedBy,
            //    Status = issue.Status.StatusId
            //};
          
        }


        [HttpPut("{id}")]
        public CreateIssueResponse PutIssue(int id, EditIssueRequest issue)
        {
            var newIssue = _mapper.Map<Issue>(issue);
            newIssue.Status = new Status { StatusName = issue.Status };
            
             _issuesLogic.EditIssue(id, newIssue);

            return new CreateIssueResponse
            {             
                Message = "Edited Succesfully"
            };

        }


        [HttpPost]
        public async Task<CreateIssueResponse> PostIssue(CreateIssueRequest issue)
        {
            var newIssue = _mapper.Map<Issue>(issue);
            newIssue.Status = new Status { StatusName = issue.Status };

            var issueId = await _issuesLogic.CreateIssue(newIssue);

            return new CreateIssueResponse { 
                IssueId = issueId,
                Message= "Issue Created Successfully"
            };
        }

        // DELETE: api/Issues/5
        [HttpDelete("{id}")]
        public CreateIssueResponse DeleteIssue(int id)
        {
            _issuesLogic.RemoveIssue(id);

            return new CreateIssueResponse
            {
                IssueId = id,
                Message = "Deleted Succesfully"
            };
        }

        //private bool IssueExists(int id)
        //{
        //    return _context.Issues.Any(e => e.IssueId == id);
        //}
    }
}

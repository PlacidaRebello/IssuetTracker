using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IssueTracker.Models;
using ServiceModel.Dto;
using AutoMapper;

namespace IssueTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssuesController : ControllerBase
    {
        private readonly DataContext _context;

        private readonly IMapper _mapper;
        public IssuesController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Issues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Issue>>> GetIssues()
        {
            return await _context.Issues.ToListAsync();
        }

        // GET: api/Issues/5
        [HttpGet("{id}")]
        public async Task<GetIssueResponse> GetIssue(int id)
        {
            //var issue = await _context.Issues.FindAsync(id);
            var issue = await _context.Issues.Include(x => x.Status).Where(x => x.IssueId == id).FirstAsync();
            //if (issue == null)
            //{
            //    return NotFound();
            //}

            return new GetIssueResponse
            {
                IssueId = issue.IssueId,
                Subject = issue.Subject,
                Description = issue.Description,
                AssignedTo = issue.AssignedTo,
                Tags = issue.Tags,
                CreatedBy = issue.CreatedBy,
                Status = issue.Status.StatusId
            };
            //return issue;
        }


        [HttpPut("{id}")]
        public async Task<CreateIssueResponse> PutIssue(int id, CreateIssueRequest issue)
        {
            //if (id != issue.IssueId)
            //{
            //    return BadRequest();
            //}

            Issue getIssue = _context.Set<Issue>().SingleOrDefault(c => c.IssueId == id);
            if (getIssue != null)
            {
                getIssue.Subject = issue.Subject;
                getIssue.Description = issue.Description;
                getIssue.AssignedTo = issue.AssignedTo;
                getIssue.CreatedBy = issue.CreatedBy;
                getIssue.Tags = issue.Tags;

                var status = _context.Status.FirstOrDefault(s => s.StatusName == issue.Status);
                //need to add code if status doensot exist create one

                getIssue.Status = status;
            }
            _context.Entry(getIssue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IssueExists(id))
                {
                    //return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return new CreateIssueResponse { 
                IssueId=getIssue.IssueId,
                Message="Edited Successfully"
            };
        }


        [HttpPost]
        public async Task<CreateIssueResponse> PostIssue(CreateIssueRequest issue)
        {


            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<Issue, CreateIssueRequest>()
            //.ForMember(dest => dest.Status,
            //opts => opts.MapFrom(src => src.Status.StatusId));
            //});

            
            var newIssue = _mapper.Map<Issue>(issue);
            //var newIssue = new Issue();

            ////Use automapper to clean this up
            //newIssue.Subject = issue.Subject;
            //newIssue.Tags = issue.Tags;
            //newIssue.AssignedTo = issue.AssignedTo;
            //newIssue.Description = issue.Description;
            //newIssue.CreatedBy = issue.CreatedBy;
            //newIssue.CreatedDate = DateTime.Now;

            ////Move this block to BL
            //var status = _context.Status.FirstOrDefault(s => s.StatusName == issue.Status);

            //if (status == null)
            //{
            //    status = new Status { StatusName = issue.Status };
            //    _context.Status.Add(status);
            //    await _context.SaveChangesAsync();
            //}
            //newIssue.Status = status;

            _context.Issues.Add(newIssue);
            await _context.SaveChangesAsync();

            return new CreateIssueResponse { 
                IssueId = newIssue.IssueId,
                Message= "Issue Created Successfully"
            };
        }

        // DELETE: api/Issues/5
        [HttpDelete("{id}")]
        public async Task<CreateIssueResponse> DeleteIssue(int id)
        {
            Issue issues = _context.Set<Issue>().SingleOrDefault(c => c.IssueId == id);

            if (issues != null)
            {
                _context.Entry(issues).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;

            }
            await _context.SaveChangesAsync();

            return new CreateIssueResponse
            {
                IssueId = id,
                Message = "Deleted Succesfully"
            };

            //var issue = await _context.Issues.FindAsync(id);
            //if (issue == null)
            //{
            //    return NotFound();
            //}

            //_context.Issues.Remove(issue);
            //await _context.SaveChangesAsync();

            //return issue;
        }

        private bool IssueExists(int id)
        {
            return _context.Issues.Any(e => e.IssueId == id);
        }
    }
}

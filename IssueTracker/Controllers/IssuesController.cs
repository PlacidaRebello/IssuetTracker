using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IssueTracker.Models;
using ServiceModel.Dto;

namespace IssueTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssuesController : ControllerBase
    {
        private readonly DataContext _context;

        public IssuesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Issues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Issue>>> GetIssues()
        {
            return await _context.Issues.ToListAsync();
        }

        // GET: api/Issues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Issue>> GetIssue(int id)
        {
            var issue = await _context.Issues.FindAsync(id);

            if (issue == null)
            {
                return NotFound();
            }

            return issue;
        }

        // PUT: api/Issues/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIssue(int id, Issue issue)
        {
            if (id != issue.IssueId)
            {
                return BadRequest();
            }

            _context.Entry(issue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IssueExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Issues
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<CreateIssueResponse> PostIssue(CreateIssueRequest issue)
        {
            var newIssue = new Issue();

            //Use automapper to clean this up
            newIssue.Subject = issue.Subject;
            newIssue.Tags = issue.Tags;
            newIssue.Description = issue.Description;
            newIssue.CreatedBy = issue.CreatedBy;
            newIssue.CreatedDate = DateTime.Now;

            //Move this block to BL
            var status = _context.Status.FirstOrDefault(s => s.StatusName == issue.Status);
            
            if (status == null)
            {
                status = new Status { StatusName = issue.Status };
                _context.Status.Add(status);
                await _context.SaveChangesAsync();
            }
            newIssue.Status = status;

            _context.Issues.Add(newIssue);
            await _context.SaveChangesAsync();

            return new CreateIssueResponse { 
                IssueId = newIssue.IssueId,
                Message= "Issue Created Successfully"
            };
        }

        // DELETE: api/Issues/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Issue>> DeleteIssue(int id)
        {
            var issue = await _context.Issues.FindAsync(id);
            if (issue == null)
            {
                return NotFound();
            }

            _context.Issues.Remove(issue);
            await _context.SaveChangesAsync();

            return issue;
        }

        private bool IssueExists(int id)
        {
            return _context.Issues.Any(e => e.IssueId == id);
        }
    }
}

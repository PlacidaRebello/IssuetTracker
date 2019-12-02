using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class IssuesEngine : IIssuesEngine
    {
        private readonly DataContext _context;
        public IssuesEngine(DataContext context)
        {
            _context = context;
        }

        public async Task<int> CreateIssue(Issue issue)
        {
            _context.Issues.Add(issue);
            await _context.SaveChangesAsync();

            return issue.IssueId;
        }
    }
}

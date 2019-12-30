using DataAccess.Interfaces;
using DataAccess.Models;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class IssuesEngine : IIssuesEngine
    {
        private readonly DataContext _context;
        public IssuesEngine(DataContext context)
        {
            _context = context;
        }

        public int CreateIssue(Issue issue)
        {
            _context.Issues.Add(issue);
            _context.SaveChanges();
            return issue.IssueId;
        }

        public bool EditIssue(Issue issue)
        {
            _context.Issues.Update(issue);
            _context.SaveChanges();
            return true;
        }

        public Issue GetIssue(int id)
        {
            return _context.Issues.FirstOrDefault(i => i.IssueId == id);
        }

        public bool RemoveIssue(Issue issue)
        {
            _context.Issues.Remove(issue);
            _context.SaveChanges();
            return true;
        }

        public bool IssueExists(int id)
        {
            return _context.Issues.Any(e => e.IssueId == id);
        }

        public List<Issue> GetIssueList()
        {
            return _context.Issues.ToList<Issue>();
        }
    }
}

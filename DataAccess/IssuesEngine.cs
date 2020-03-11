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
            //var issueItem = _context.Issues.OrderByDescending(i => i.Order).FirstOrDefault();            
            //issue.Order = issueItem == null ? 1 : issueItem.Order + 1;

            _context.Issues.Add(issue);
            _context.SaveChanges();
            return issue.IssueId;
        }

        public bool EditIssue(Issue issue)
        {
            //issue.Order= _context.Issues.FirstOrDefault(i => i.IssueId == issue.IssueId).Order;
            issue.Order = (from Issue in _context.Issues
                           where Issue.IssueId ==issue.IssueId
                           select Issue.Order
                         ).FirstOrDefault();
            _context.Issues.Update(issue);
            _context.SaveChanges();
            return true;
        }

        public Issue GetIssue(int id)
        {
            //return _context.Issues.FirstOrDefault(i => i.IssueId == id);
            var issue = (from IssueStatus in _context.IssueStatus
                         join Issue in _context.Issues
                         on IssueStatus.IssueStatusId equals Issue.IssueStatusId
                         where Issue.IssueId == id
                         select new Issue
                         {
                             IssueId = Issue.IssueId,
                             Subject = Issue.Subject,
                             Description = Issue.Description,
                             AssignedTo = Issue.AssignedTo,
                             Tags = Issue.Tags,
                             IssueStatusId = IssueStatus.IssueStatusId,
                             StatusName = IssueStatus.StatusName,
                             Order = Issue.Order
                         }).FirstOrDefault();

            return issue;
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

        public Issue IssueExists() 
        {
           return _context.Issues.OrderByDescending(i => i.Order).FirstOrDefault();
        }

        public List<Issue> GetIssueList()
        {
            // return _context.Issues.ToList<Issue>();
            var issueList = (from IssueStatus in _context.IssueStatus
                         join Issue in _context.Issues
                         on IssueStatus.IssueStatusId equals Issue.IssueStatusId
                             orderby Issue.Order ascending
                             select new Issue
                         {
                             IssueId = Issue.IssueId,
                             Subject = Issue.Subject,
                             Description = Issue.Description,
                             AssignedTo = Issue.AssignedTo,
                             Tags = Issue.Tags,
                             IssueStatusId = IssueStatus.IssueStatusId,
                             StatusName=IssueStatus.StatusName,
                             Order=Issue.Order
                         }).ToList();

            return issueList;
        }

        public List<Issue> GetIssueListByStatus(int issueStatus) 
        {
            var issueList = (from IssueStatus in _context.IssueStatus
                             join Issue in _context.Issues
                             on IssueStatus.IssueStatusId equals Issue.IssueStatusId
                             where IssueStatus.IssueStatusId == issueStatus
                             orderby Issue.Order ascending
                             select new Issue
                             {
                                 IssueId = Issue.IssueId,
                                 Subject = Issue.Subject,
                                 Description = Issue.Description,
                                 AssignedTo = Issue.AssignedTo,
                                 Tags = Issue.Tags,
                                 IssueStatusId = IssueStatus.IssueStatusId,
                                 StatusName = IssueStatus.StatusName,
                                 Order = Issue.Order
                             }).ToList();

            return issueList;
        }
        public bool DragDropIssueList(List<Issue> issues)
        {
            _context.Issues.UpdateRange(issues);
            _context.SaveChanges();
            return true;
        }
    }
}

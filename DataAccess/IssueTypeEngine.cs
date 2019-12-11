using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class IssueTypeEngine : IIssueTypeEngine
    {
        private readonly DataContext _context;
        public IssueTypeEngine(DataContext context)
        {
            _context = context;
        }

        public int CreateIssueType(IssueType newIssueType)
        {
            _context.IssueType.Add(newIssueType);
             _context.SaveChanges();
            return newIssueType.IssueTypeId;
        }

        public bool EditIssueType(IssueType newIssueType)
        {
            _context.IssueType.Update(newIssueType);
            _context.SaveChanges();
            return true;
        }

        public IssueType GetIssueType(int id)
        {
            return _context.IssueType.FirstOrDefault(i => i.IssueTypeId == id);
        }

        public bool IssueTypeExists(int id)
        {
            return _context.IssueType.Any(e => e.IssueTypeId == id);
        }

        public bool RemoveIssueType(IssueType issueType)
        {
            _context.IssueType.Remove(issueType);
            _context.SaveChanges();
            return true;
        }
    }
}

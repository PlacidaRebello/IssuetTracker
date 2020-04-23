using DataAccess.Interfaces;
using DataAccess.Models;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class IssueStatusEngine : IIssueStatusEngine
    {
        private readonly DataContext _context;
        public IssueStatusEngine(DataContext context)
        {
            _context = context;
        }

        public int CreateStatus(IssueStatus status)
        {
            _context.IssueStatus.Add(status);
            _context.SaveChanges();
            return status.IssueStatusId;
        }

        public bool EditStatus(IssueStatus newStatus)
        {

            _context.IssueStatus.Update(newStatus);
            _context.SaveChanges();
            return true;
        }

        public IssueStatus GetStatus(int id)
        {
            return _context.IssueStatus.FirstOrDefault(s => s.IssueStatusId == id);
        }

        public IssueStatus GetStatusByName(string statusName)
        {
            return _context.IssueStatus.FirstOrDefault(s => s.StatusName == statusName);
        }

        public List<IssueStatus> GetStatusList()
        {
            return _context.IssueStatus.ToList<IssueStatus>();
        }

        public bool RemoveStatus(IssueStatus status)
        {
            _context.IssueStatus.Remove(status);
            _context.SaveChanges();
            return true;
        }

        public bool StatusExists(string status)
        {
            return _context.IssueStatus.Any(e => e.StatusName == status);
        }

        public bool StatusExists(int id)
        {
            return _context.IssueStatus.Any(e => e.IssueStatusId == id);
        }

       
    }
}

using DataAccess.Interfaces;
using ServiceModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public List<IssueType> GetIssueTypeList()
        {
            return Enum.GetValues(typeof(DataModels.IssueType))
               .Cast<DataModels.IssueType>()
               .Select(t => new IssueType
               {
                   IssueTypeId = (int)t,
                   IssueTypeName = t.ToString()
               }).ToList();
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

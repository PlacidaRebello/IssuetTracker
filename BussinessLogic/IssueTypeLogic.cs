using BussinessLogic.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic
{
    public class IssueTypeLogic : IIssueTypeLogic
    {
        private readonly IIssueTypeEngine _issueTypeEngine;
        public IssueTypeLogic(IIssueTypeEngine issueTypeEngine)
        {
            _issueTypeEngine = issueTypeEngine;
        }

        public async Task<int> CreateIssueType(IssueType newIssueType)
        {
            return await _issueTypeEngine.CreateIssueType(newIssueType);
        }

        public void EditIssueType(IssueType newIssueType)
        {
            if (!_issueTypeEngine.IssueTypeExists(newIssueType.IssueTypeId))
            {
                throw new Exception("IssueType Does not exists");
            }
            _issueTypeEngine.EditIssueType(newIssueType);
        }

        public IssueType GetIssueType(int id)
        {
            return _issueTypeEngine.GetIssueType(id);   
        }

        public void RemoveIssueType(int id)
        {
            var issueType = _issueTypeEngine.GetIssueType(id);
            if (issueType==null)
            {
                throw new Exception("IssueType Does not exists");
            }
            _issueTypeEngine.RemoveIssueType(issueType);
        }
    }
}

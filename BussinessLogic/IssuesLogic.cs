using BussinessLogic.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfaces;

namespace BussinessLogic
{
    public class IssuesLogic : IIssuesLogic
    {
        private readonly IIssuesEngine _issuesEngine;
        private readonly IStatusLogic _statusLogic;
        public IssuesLogic(IIssuesEngine issuesEngine, IStatusLogic statusEngine)
        {
            _issuesEngine = issuesEngine;
            _statusLogic = statusEngine;
        }

        public Issue GetIssue(int id)
        {
            return _issuesEngine.GetIssue(id);
        }

        public int CreateIssue(Issue issue)
        {
            var status = _statusLogic.GetStatusByName(issue.Status.StatusName);
            if (status == null)
            {
                throw new Exception("Status doesn't exist. Please create a status and then add Issues");
            }
            issue.Status = status;
            return _issuesEngine.CreateIssue(issue);
        }

        public bool RemoveIssue(int id)
        {
            var issue = _issuesEngine.GetIssue(id);
            if (issue == null)
            {
                throw new Exception("Issue does not exists");
            }
            return _issuesEngine.RemoveIssue(issue);
        }

        public bool EditIssue(Issue issue)
        {
            if (!_issuesEngine.IssueExists(issue.IssueId))
            {
                throw new Exception("Issue does not exists");
            }
            return _issuesEngine.EditIssue(issue);
        }
    }
}

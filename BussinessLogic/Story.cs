using BussinessLogic.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Models;

namespace BussinessLogic
{
    public class Story : IIssue
    {

        private readonly IIssuesEngine _issuesEngine;
        public Story(IIssuesEngine issuesEngine)
        {
            _issuesEngine = issuesEngine;
        }

        public int Create(Issue issue)
        {
            int issueId = _issuesEngine.CreateIssue(issue);
            return issueId;
        }
    }
}

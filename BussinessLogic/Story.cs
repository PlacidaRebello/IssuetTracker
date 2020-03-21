using BussinessLogic.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

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

            IssueDetails issueDetails = issue.IssueDetails;
            issueDetails.IssueId = issueId;

            _issuesEngine.AddIssueDetails(issueDetails);
            return issueId;
        }
    }
}

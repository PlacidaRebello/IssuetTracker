using BussinessLogic.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLogic
{
    public class Story : IIssue
    {

        private readonly IIssuesLogic _issuesLogic;
        //public Story(IIssuesLogic issuesLogic)
        //{
        //    _issuesLogic = issuesLogic;
        //}

        public int Create(Issue issue, IssueDetails issueDetails)
        {
            int issueId = _issuesLogic.CreateIssue(issue);
            issueDetails.IssueId = issueId;
            _issuesLogic.AddIssueDetails(issueDetails);
            return issueId;
        }
    }
}

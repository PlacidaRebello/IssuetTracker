using BussinessLogic.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLogic
{
    public class Bug : IIssue
    {

        private readonly IIssuesLogic _issuesLogic;
        //public Bug(IIssuesLogic issuesLogic)
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

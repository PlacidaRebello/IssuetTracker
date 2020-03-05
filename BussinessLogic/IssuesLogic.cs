using BussinessLogic.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;

namespace BussinessLogic
{
    public class IssuesLogic : IIssuesLogic
    {
        private readonly IIssuesEngine _issuesEngine;
        private readonly IIssueStatusLogic _issueStatusLogic;
        public IssuesLogic(IIssuesEngine issuesEngine, IIssueStatusLogic statusEngine)
        {
            _issuesEngine = issuesEngine;
            _issueStatusLogic = statusEngine;
        }

        public Issue GetIssue(int id)
        {
            return _issuesEngine.GetIssue(id);
        }

        public int CreateIssue(Issue issue)
        {
            //var status = _issueStatusLogic.GetStatus(issue.IssueStatusId);
            //if (status == null)
            //{
            //    throw new Exception("Status doesn't exist. Please create a status and then add Issues");
            //}
            // issue.IssueStatus = status;
            issue.CreatedDate = DateTime.Now;
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
            issue.CreatedDate = DateTime.Now;
            return _issuesEngine.EditIssue(issue);
        }

        public List<Issue> GetIssueList()
        {
            return _issuesEngine.GetIssueList();
        }

        public bool DragDropIssues(bool previtem, int prevItemId, int nextItemId, int currentItemIndex, string issueStatus, int issueId)
        {
            Issue issue = _issuesEngine.GetIssue(issueId);
            Issue prevIssue, NextIssue;

            List<Issue> issues = _issuesEngine.GetIssueListByStatus(issueStatus);

            if (currentItemIndex >= (issues.Count / 2))
            {
                if (previtem)
                {
                    prevIssue = _issuesEngine.GetIssue(prevItemId);
                    issue.Order = prevIssue.Order + 1;
                }
                else
                {
                    NextIssue = _issuesEngine.GetIssue(nextItemId);
                    issue.Order = NextIssue.Order - 1;
                }
            }
            else
            {
                if (previtem)
                {
                    prevIssue = _issuesEngine.GetIssue(prevItemId);
                    issue.Order = prevIssue.Order;
                    //  prevItemOrder = prevItemOrder - 1;//this should go in loop
                }
                else
                {
                    NextIssue = _issuesEngine.GetIssue(nextItemId);
                    issue.Order = NextIssue.Order - 1;
                }
            }
            // issue belongs to 2nd half
            for (int i = currentItemIndex; i < issues.Count; i++)
            {
                if (issues[i].Order <= issue.Order)
                {
                    issues[i].Order = issue.Order + 1;
                    int j = i;
                }
                else if (i > 0 && issues[i].Order <= issues[i - 1].Order)
                {
                    issues[i].Order = issues[i - 1].Order + 1;
                }
            }
            //isue belongs to 1st half
            //for (int i = currentItemIndex; i >0; i--)
            //{
            //    if (issues[i].Order >= issue.Order)
            //    {
            //        issues[i].Order = issue.Order - 1;
            //        int j = i;
            //    }
            //    else if (i > 0 && issues[i].Order <= issues[i - 1].Order)
            //    {
            //        issues[i].Order = issues[i - 1].Order + 1;
            //    }
            //}   

            return true;
        }
    }
}

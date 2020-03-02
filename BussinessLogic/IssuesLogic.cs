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

        public bool DragDropIssues(bool previtem,int prevItemOrder,int nextItemOrder,int currentItemOrder,int currentItemIndex,int noOfItems, string issueType) 
        {
            List<Issue> issues= _issuesEngine.GetIssueListByIssueType(issueType);
            int itemOrder;
            int nextItem;
            if (currentItemIndex>=noOfItems/2)
            {
                if (previtem)
                {
                    itemOrder = prevItemOrder + 1;
                }
                else
                {
                    itemOrder = nextItemOrder - 1;
                }
                //this should go in for loop for remaining items of list
                if (itemOrder>=nextItemOrder)
                {
                    nextItem = nextItemOrder + 1;
                }
            }
            else
            {
                if (previtem)
                {
                    itemOrder = prevItemOrder;
                    prevItemOrder = prevItemOrder - 1;//this should go in loop
                }
                else {
                    itemOrder = nextItemOrder - 1;
                }
            }
            return true;
        }
    }
}

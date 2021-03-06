﻿using BussinessLogic.Factory;
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
        private readonly IDragDropLogic _dragDropLogic;
        public IssuesLogic(IIssuesEngine issuesEngine, IDragDropLogic dragDropLogic)
        {
            _issuesEngine = issuesEngine;
            _dragDropLogic = dragDropLogic;
        }

        public Issue GetIssue(int id)
        {
            return _issuesEngine.GetIssue(id);
        }

        public int CreateIssue(Issue issue)
        {
            if (_issuesEngine.IssueExists())
            {
                issue.Order = _issuesEngine.GetMaxOrder() + 1;
            }
            else
            {
                issue.Order = 1;
            }
            issue.CreatedDate = DateTime.Now;
            var issueManager = IssuesFactory.GetIssueManager(issue.IssueTypeId, _issuesEngine);
            var issueId = issueManager.Create(issue);
            return issueId;
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
        
        public bool DragDropIssues(bool previtem, int prevItemId, int nextItemId, int currentItemIndex, int issueStatus, int issueId)
        {
            var issue = _issuesEngine.GetIssue(issueId);
            issue.IssueStatusId = issueStatus;
            var issues = _issuesEngine.GetIssueListByStatus(issueStatus);

            var reOrderedIssues = _dragDropLogic.DropItem(previtem, prevItemId, nextItemId, currentItemIndex, issue, issues);
            return _issuesEngine.DragDropIssueList(reOrderedIssues);
        }
    }
}
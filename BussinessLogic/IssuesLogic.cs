﻿using BussinessLogic.Interfaces;
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


        public IssuesLogic(IIssuesEngine issuesEngine, IStatusLogic statusLogic)
        {
            _issuesEngine = issuesEngine;
            _statusLogic = statusLogic;
        }

        public Issue GetIssue(int id) 
        {
            return _issuesEngine.GetIssue(id);
        }

        public async Task<int> CreateIssue(Issue issue)
        {
            var status = await _statusEngine.GetStatusByName(issue.Status.StatusName);

            if (status == null)
            {
                throw new Exception("Status doesn't exist. Please create a status and then add Issues");
            }

            issue.Status = status;
            return await _issuesEngine.CreateIssue(issue);
        }

        public void RemoveIssue(int id)
        {
            var issue = _issuesEngine.GetIssue(id);

            if (issue == null)
            {
                throw new Exception("Issue does not exists");
            }
            else
            {
                _issuesEngine.RemoveIssue(issue);
            }
        }

        public void EditIssue(int id, Issue issue)
        {
            //var oldIssue = _issuesEngine.GetIssue(id);
            
            if (!_issuesEngine.IssueExists(id))
            {
                throw new Exception("Issue does not exists");
            }
            _issuesEngine.EditIssue(id,issue); 
        }
    }
}
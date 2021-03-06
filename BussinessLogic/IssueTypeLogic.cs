﻿using BussinessLogic.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;

namespace BussinessLogic
{
    public class IssueTypeLogic : IIssueTypeLogic
    {
        private readonly IIssueTypeEngine _issueTypeEngine;
        public IssueTypeLogic(IIssueTypeEngine issueTypeEngine)
        {
            _issueTypeEngine = issueTypeEngine;
        }

        public int CreateIssueType(IssueType newIssueType)
        {
            newIssueType.CreatedDate = DateTime.Now;
            return _issueTypeEngine.CreateIssueType(newIssueType);
        }

        public bool EditIssueType(IssueType newIssueType)
        {
            if (!_issueTypeEngine.IssueTypeExists(newIssueType.IssueTypeId))
            {
                throw new Exception("IssueType Does not exists");
            }
            newIssueType.CreatedDate = DateTime.Now;
            _issueTypeEngine.EditIssueType(newIssueType);
            return true;
        }

        public IssueType GetIssueType(int id)
        {
            return _issueTypeEngine.GetIssueType(id);
        }

        public List<IssueType> GetIssueTypeList()
        {
            return _issueTypeEngine.GetIssueTypeList();
        }

        public bool RemoveIssueType(int id)
        {
            var issueType = _issueTypeEngine.GetIssueType(id);
            if (issueType == null)
            {
                throw new Exception("IssueType Does not exists");
            }
            _issueTypeEngine.RemoveIssueType(issueType);
            return true;
        }
    }
}

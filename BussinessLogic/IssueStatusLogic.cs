using BussinessLogic.Interfaces;
using DataAccess.Interfaces;
using ServiceModel.Models;
using System;
using System.Collections.Generic;

namespace BussinessLogic
{
    public class IssueStatusLogic : IIssueStatusLogic
    {
        private readonly IIssueStatusEngine _issueStatusEngine;
        public IssueStatusLogic(IIssueStatusEngine issueStatusEngine)
        {
            _issueStatusEngine = issueStatusEngine;
        }
        public int CreateStatus(IssueStatus status)
        {
            return _issueStatusEngine.CreateStatus(status);
        }

        public bool EditStatus(IssueStatus newStatus)
        {
            if (!_issueStatusEngine.StatusExists(newStatus.IssueStatusId))
            {
                throw new Exception("Status Doesnot exists ");
            }
            _issueStatusEngine.EditStatus(newStatus);
            return true;
        }

       
        public IssueStatus GetStatus(int id)
        {
            return _issueStatusEngine.GetStatus(id);
        }

        public IssueStatus GetStatusByName(string statusName)
        {
            return _issueStatusEngine.GetStatusByName(statusName);
        }

        public List<IssueStatus> GetStatusList()
        {
            return _issueStatusEngine.GetStatusList();
        }

        public bool RemoveStatus(int id)
        {
            var status = _issueStatusEngine.GetStatus(id);
            if (status == null)
            {
                throw new Exception("Status doesnot exists");
            }
            _issueStatusEngine.RemoveStatus(status);
            return true;
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace DataAccess.Interfaces
{
    public interface IIssueTypeEngine
    {
        IssueType GetIssueType(int id);
        bool IssueTypeExists(int id);
        void EditIssueType(IssueType newIssueType);
        Task<int> CreateIssueType(IssueType newIssueType);
        void RemoveIssueType(IssueType issueType);
    }
}

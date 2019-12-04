using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Interfaces
{
    public interface IIssueTypeLogic
    {
        IssueType GetIssueType(int id);
        void EditIssueType(IssueType newIssueType);
        Task<int> CreateIssueType(IssueType newIssueType);
        void RemoveIssueType(int id);
    }
}

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
        bool EditIssueType(IssueType newIssueType);
        int CreateIssueType(IssueType newIssueType);
        bool RemoveIssueType(int id);
    }
}

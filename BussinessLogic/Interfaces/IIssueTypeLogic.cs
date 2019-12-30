using DataAccess.Models;
using System.Collections.Generic;

namespace BussinessLogic.Interfaces
{
    public interface IIssueTypeLogic
    {
        IssueType GetIssueType(int id);
        bool EditIssueType(IssueType newIssueType);
        int CreateIssueType(IssueType newIssueType);
        bool RemoveIssueType(int id);
        List<IssueType> GetIssueTypeList();
    }
}

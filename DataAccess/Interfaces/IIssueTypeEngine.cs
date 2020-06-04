using ServiceModel.Models;
using System.Collections.Generic;

namespace DataAccess.Interfaces
{
    public interface IIssueTypeEngine
    {
        IssueType GetIssueType(int id);
        bool IssueTypeExists(int id);
        bool EditIssueType(IssueType newIssueType);
        int CreateIssueType(IssueType newIssueType);
        bool RemoveIssueType(IssueType issueType);
        List<IssueType> GetIssueTypeList();
    }
}

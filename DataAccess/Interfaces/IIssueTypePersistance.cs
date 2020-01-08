using DataAccess.Models;
using System.Collections.Generic;

namespace DataAccess.Interfaces
{
    public interface IIssueTypePersistence
    {
        IssueType GetIssueType(int id);
        bool IssueTypeExists(int id);
        bool EditIssueType(IssueType newIssueType);
        int CreateIssueType(IssueType newIssueType);
        bool RemoveIssueType(IssueType issueType);
        List<IssueType> GetIssueTypeList();
    }
}

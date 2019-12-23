using DataAccess.Models;

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

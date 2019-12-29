using DataAccess.Models;

namespace DataAccess.Interfaces
{
    public interface IIssuesEngine
    {
        int CreateIssue(Issue issue);
        Issue GetIssue(int id);
        bool RemoveIssue(Issue issue);
        bool EditIssue(Issue issue);
        bool IssueExists(int id);
        //Issue GetIssueByName(string issueName);
    }
}

using ServiceModel.Models;
using System.Collections.Generic;

namespace DataAccess.Interfaces
{
    public interface IIssuesEngine
    {
        int CreateIssue(Issue issue);
        Issue GetIssue(int id);
        bool RemoveIssue(Issue issue);
        bool EditIssue(Issue issue);
        bool IssueExists(int id);
        List<Issue> GetIssueList();
        List<Issue> GetIssueListByStatus(int issueStatus);
        bool DragDropIssueList(List<Issue> issues);
        int GetMaxOrder();
        bool IssueExists();
    }
}

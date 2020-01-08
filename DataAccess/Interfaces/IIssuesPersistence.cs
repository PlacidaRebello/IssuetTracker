using DataAccess.Models;
using System.Collections.Generic;

namespace DataAccess.Interfaces
{
    public interface IIssuesPersistence
    {
        int CreateIssue(Issue issue);
        Issue GetIssue(int id);
        bool RemoveIssue(Issue issue);
        bool EditIssue(Issue issue);
        bool IssueExists(int id);
        List<Issue> GetIssueList();
    }
}

using DataAccess.Models;
using System.Collections.Generic;

namespace BussinessLogic.Interfaces
{
    public interface IIssuesLogic
    {
        int CreateIssue(Issue issue);
        bool RemoveIssue(int id);
        Issue GetIssue(int id);
        bool EditIssue(Issue issue);
        List<Issue> GetIssueList();
    }
}

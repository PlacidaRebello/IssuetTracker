using DataAccess.Models;

namespace BussinessLogic.Interfaces
{
    public interface IIssuesLogic
    {
        int CreateIssue(Issue issue);
        bool RemoveIssue(int id);
        Issue GetIssue(int id);
        bool EditIssue(Issue issue);
    }
}

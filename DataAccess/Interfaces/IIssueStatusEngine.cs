using ServiceModel.Models;
using System.Collections.Generic;

namespace DataAccess.Interfaces
{
    public interface IIssueStatusEngine
    {
        int CreateStatus(IssueStatus status);
        IssueStatus GetStatusByName(string statusName);
        bool RemoveStatus(IssueStatus status);
        bool StatusExists(int id);
        IssueStatus GetStatus(int id);
        bool EditStatus(IssueStatus newStatus);
        List<IssueStatus> GetStatusList();
    }
}

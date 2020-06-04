using ServiceModel.Models;
using System.Collections.Generic;

namespace BussinessLogic.Interfaces
{
    public interface IIssueStatusLogic
    {
        int CreateStatus(IssueStatus status);
        IssueStatus GetStatusByName(string statusName);
        bool RemoveStatus(int id);
        IssueStatus GetStatus(int id);
        bool EditStatus(IssueStatus newStatus);
        List<IssueStatus> GetStatusList();
    }
}

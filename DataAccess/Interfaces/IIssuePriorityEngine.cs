using ServiceModel.Models;
using System.Collections.Generic;

namespace DataAccess.Interfaces
{
    public interface IIssuePriorityEngine
    {
        List<Issue> GetManagementIssuesList();
        List<IssuePriority> GetIssueListByPriority();
        IssuePriority GetIssuePriorityById(int id);
        bool UpdateIssuePriorities(List<IssuePriority> issues);
        List<IssuesCountByType> GetIssuesByType();
        List<DailyBurnDown>  GetDataForBurnDownChart();
    }
}

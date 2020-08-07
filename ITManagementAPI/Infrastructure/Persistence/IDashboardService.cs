using ITManagementAPI.Application.Management.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Models;

namespace ITManagementAPI.Infrastructure.Persistence
{
    public interface IDashboardService
    {
        public Task<List<Issue>> GetManagementIssuesList();
       public List<IssuePriority> GetIssueListByPriority();
       public IssuePriority GetIssuePriorityById(int id);
       public Task<bool> UpdateIssuePriorities(List<IssuePriority> issues);
       public  List<IssuesCountByType> GetIssuesCountByType();
       public Task<List<DailyBurnDown>> GetDataForBurnDownChart();
    }
}

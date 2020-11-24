using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLogic.Interfaces
{
   public interface IIssuePriorityLogic
    {
        List<IssuePriority> UpdateIssuePrirority(bool previtem, int prevItemId, int nextItemId, int currentItemIndex, int issueId);
        List<Issue> GetManagementIssuesList();
        List<IssuesCountByType> GetIssuesCountByTypes();
        List<DailyBurnDown> GetDailyBurnDowns();
    }
}

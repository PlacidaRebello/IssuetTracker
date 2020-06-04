using BussinessLogic.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Models;
using System.Collections.Generic;

namespace BussinessLogic
{
    public class IssuePriorityLogic : IIssuePriorityLogic
    {
        private readonly IIssuePriorityEngine _issuePriorityEngine;

        public IssuePriorityLogic(IIssuePriorityEngine issuePriorityEngine)
        {
            _issuePriorityEngine = issuePriorityEngine;
        }

        public List<IssuesCountByType> GetIssuesCountByTypes()
        {
            return _issuePriorityEngine.GetIssuesByType();
        }

        public List<Issue> GetManagementIssuesList()
        {
            return _issuePriorityEngine.GetManagementIssuesList();
        }
        public bool UpdateIssuePrirority(bool previtem, int prevItemId, int nextItemId, int currentItemIndex, int issueId)
        {
            var issue = _issuePriorityEngine.GetIssuePriorityById(issueId);
            var issues = _issuePriorityEngine.GetIssueListByPriority();

            var item = issues.Find(x => x.IssueId == issue.IssueId);
            if (item != null)
                issues.Remove(item);

            IssuePriority prevIssue, NextIssue;
            if (currentItemIndex >= decimal.Divide(issues.Count, 2))
            {
                if (previtem)
                {
                    prevIssue = _issuePriorityEngine.GetIssuePriorityById(prevItemId);
                    issue.IssueOrder = prevIssue.IssueOrder + 1;
                }
                else
                {
                    NextIssue = _issuePriorityEngine.GetIssuePriorityById(nextItemId);
                    issue.IssueOrder = NextIssue.IssueOrder - 1;
                }
                // issue belongs to 2nd half
                for (int i = currentItemIndex; i < issues.Count; i++)
                {
                    if (issues[i].IssueOrder <= issue.IssueOrder)
                    {
                        issues[i].IssueOrder = issue.IssueOrder + 1;
                    }
                    else if (i > 0 && issues[i].IssueOrder <= issues[i - 1].IssueOrder)
                    {
                        issues[i].IssueOrder = issues[i - 1].IssueOrder + 1;
                    }
                }
            }
            else
            {
                if (previtem)
                {
                    prevIssue = _issuePriorityEngine.GetIssuePriorityById(prevItemId);
                    issue.IssueOrder = prevIssue.IssueOrder;
                }
                else
                {
                    NextIssue = _issuePriorityEngine.GetIssuePriorityById(nextItemId);
                    issue.IssueOrder = NextIssue.IssueOrder - 1;
                }
                //isue belongs to 1st half
                for (int i = currentItemIndex - 1; i >= 0; i--)
                {
                    if (issues[i].IssueOrder >= issue.IssueOrder)
                    {
                        issues[i].IssueOrder = issue.IssueOrder - 1;
                        int j = i;
                    }
                    if (issues[i].IssueOrder >= issues[i + 1].IssueOrder)
                    {
                        issues[i].IssueOrder = issues[i + 1].IssueOrder - 1;
                    }
                }
            }

            issues.Add(issue);
            return _issuePriorityEngine.UpdateIssuePriorities(issues);

        }

        public List<DailyBurnDown> GetDailyBurnDowns() 
        {
            return _issuePriorityEngine.GetDataForBurnDownChart();
        }
    }
}

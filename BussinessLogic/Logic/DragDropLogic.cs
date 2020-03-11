using BussinessLogic.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Models;
using System.Collections.Generic;

namespace BussinessLogic.Logic
{
    public class DragDropLogic:IDragDropLogic
    {
        private readonly IIssuesEngine _issuesEngine;
        public DragDropLogic(IIssuesEngine issuesEngine)
        {
            _issuesEngine = issuesEngine;
        }
        public List<Issue> DropItem(bool previtem, int prevItemId, int nextItemId, int currentItemIndex,Issue issue,List<Issue> issues)
        {
            Issue prevIssue, NextIssue;
            var item = issues.Find(x => x.IssueId == issue.IssueId);
            if (item != null)
                issues.Remove(item);
            if (currentItemIndex >= decimal.Divide(issues.Count, 2))
            {
                if (previtem)
                {
                    prevIssue = _issuesEngine.GetIssue(prevItemId);
                    issue.Order = prevIssue.Order + 1;
                }
                else
                {
                    NextIssue = _issuesEngine.GetIssue(nextItemId);
                    issue.Order = NextIssue.Order - 1;
                }
                // issue belongs to 2nd half
                for (int i = currentItemIndex; i < issues.Count; i++)
                {
                    if (issues[i].Order <= issue.Order)
                    {
                        issues[i].Order = issue.Order + 1;
                    }
                    else if (i > 0 && issues[i].Order <= issues[i-1].Order)
                    {
                        issues[i].Order = issues[i-1].Order + 1;
                    }
                }
            }
            else
            {
                if (previtem)
                {
                    prevIssue = _issuesEngine.GetIssue(prevItemId);
                    issue.Order = prevIssue.Order;
                }
                else
                {
                    NextIssue = _issuesEngine.GetIssue(nextItemId);
                    issue.Order = NextIssue.Order - 1;
                }
                //isue belongs to 1st half
                for (int i = currentItemIndex - 1; i >= 0; i--)
                {
                    if (issues[i].Order >= issue.Order)
                    {
                        issues[i].Order = issue.Order - 1;
                        int j = i;
                    }
                    if (issues[i].Order >= issues[i + 1].Order)
                    {
                        issues[i].Order = issues[i + 1].Order - 1;
                    }
                }
            }

            issues.Add(issue);
            return issues;
        }
    }
}

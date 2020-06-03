using BussinessLogic.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Models;
using System.Collections.Generic;

namespace BussinessLogic.Logic
{
    public class DragDropLogic : IDragDropLogic
    {
        private readonly IIssuesEngine _issuesEngine;
        public DragDropLogic(IIssuesEngine issuesEngine)
        {
            _issuesEngine = issuesEngine;
        }
        public List<Issue> DropItem(bool previtem, int prevItemId, int nextItemId, int currentItemIndex, Issue issue, List<Issue> issues)
        {
            Issue prevIssue, NextIssue;
            RemoveIssueFromOldIssueList(issue, ref issues);//existing issueList

            if (CheckIfIssueIsInBottomHalfOfList(currentItemIndex, issues.Count))
            {
                //issue Belongs to 2nd half of list
                //change issueorder
                ChangeIssueOrder(previtem, prevItemId, nextItemId, ref issue);
                //change the remaining issues order
                ReOrderSubsequentIssues(currentItemIndex, issue, ref issues);
            }
            else
            {
                //issue belongs to 1st half
                //change issue order
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
                //chnge remaining issue order
                ReOrderPriorIssues(currentItemIndex, issue, ref issues);
            }
            issues.Add(issue);
            return issues;
        }

        private static bool CheckIfIssueIsInBottomHalfOfList(int currentItemIndex, int count)
        {
            return currentItemIndex >= decimal.Divide(count, 2);
        }

        public void RemoveIssueFromOldIssueList(Issue issue, ref List<Issue> issues)
        {
            var item = issues.Find(x => x.IssueId == issue.IssueId);
            if (item != null)
                issues.Remove(item);
        }
        public void ChangeIssueOrder(bool previtem, int prevItemId, int nextItemId, ref Issue issue)
        {
            Issue prevIssue, NextIssue;
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
        }
        public void ReOrderPriorIssues(int currentItemIndex, Issue issue, ref List<Issue> issues)
        {
            for (int i = currentItemIndex - 1; i >= 0; i--)
            {
                if (issues[i].Order >= issue.Order)
                {
                    issues[i].Order = issue.Order - 1;
                }
                if (issues[i].Order >= issues[i + 1].Order)
                {
                    issues[i].Order = issues[i + 1].Order - 1;
                }
            }
        }
        public void ReOrderSubsequentIssues(int currentItemIndex, Issue issue, ref List<Issue> issues)
        {
            for (int i = currentItemIndex; i < issues.Count; i++)
            {
                if (issues[i].Order <= issue.Order)
                {
                    issues[i].Order = issue.Order + 1;
                }
                else if (i > 0 && issues[i].Order <= issues[i - 1].Order)
                {
                    issues[i].Order = issues[i - 1].Order + 1;
                }
            }
        }
    }
}

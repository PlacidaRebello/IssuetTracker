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
            RemoveIssueFromOldIssueList(issue, ref issues);
            ReorderIssuesInNewList(previtem, prevItemId, nextItemId, currentItemIndex, ref issue, ref issues);

            issues.Add(issue);
            return issues;
        }

        private void ReorderIssuesInNewList(bool previtem, int prevItemId, int nextItemId, int currentItemIndex, ref Issue issue, ref List<Issue> issues)
        {
            if (CheckIfIssueIsInBottomHalfOfList(currentItemIndex, issues.Count))
            {
                DetermineNewIssueOrder(previtem, prevItemId, nextItemId, ref issue);
                ReorderSubsequentIssues(currentItemIndex, issue, ref issues);
            }
            else
            {
                ApplyNewOrderToIssue(previtem, prevItemId, nextItemId, ref issue);
                ReorderPriorIssues(currentItemIndex, issue, ref issues);
            }
        }

        private void ApplyNewOrderToIssue(bool previtem, int prevItemId, int nextItemId, ref Issue issue)
        {
            if (previtem)
            {
                var prevIssue = _issuesEngine.GetIssue(prevItemId);
                issue.Order = prevIssue.Order;
            }
            else
            {
                var NextIssue = _issuesEngine.GetIssue(nextItemId);
                issue.Order = NextIssue.Order - 1;
            }
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
        public void DetermineNewIssueOrder(bool previtem, int prevItemId, int nextItemId, ref Issue issue)
        {
            if (previtem)
            {
                var prevIssue = _issuesEngine.GetIssue(prevItemId);
                issue.Order = prevIssue.Order + 1;
            }
            else
            {
                var NextIssue = _issuesEngine.GetIssue(nextItemId);
                issue.Order = NextIssue.Order - 1;
            }
        }
        public void ReorderPriorIssues(int currentItemIndex, Issue issue, ref List<Issue> issues)
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
        public void ReorderSubsequentIssues(int currentItemIndex, Issue issue, ref List<Issue> issues)
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

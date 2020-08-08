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
                var obj = new DragDropContext(new DropItemToBottom(_issuesEngine));
                obj.DetermineNewIssueOrder(previtem, prevItemId, nextItemId, ref issue);
                obj.ReorderIssues(currentItemIndex, ref issue, ref issues);
            }
            else
            {
                var obj = new DragDropContext(new DropItemToTop(_issuesEngine));
                obj.DetermineNewIssueOrder(previtem, prevItemId, nextItemId, ref issue);
                obj.ReorderIssues(currentItemIndex, ref issue, ref issues);
            }
        }

        private static bool CheckIfIssueIsInBottomHalfOfList(int currentItemIndex, int count)
        {
            return currentItemIndex >= decimal.Divide(count, 2);
        }

        private static void RemoveIssueFromOldIssueList(Issue issue, ref List<Issue> issues)
        {
            var item = issues.Find(x => x.IssueId == issue.IssueId);
            if (item != null)
                issues.Remove(item);
        }
    }
}

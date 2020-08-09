using System.Collections.Generic;
using DataAccess.Interfaces;
using DataAccess.Models;

namespace BussinessLogic.Logic
{
    /// <summary>
    /// Drop item to Bottom half Concrete Strategy class
    /// </summary>
    public class DropItemToBottom : DragDopStrategy
    {        
        private readonly IIssuesEngine _issuesEngine;
        
        public DropItemToBottom(IIssuesEngine issuesEngine)
        {
            _issuesEngine = issuesEngine;
        }
        
        public override void DetermineNewIssueOrder(bool previousItem, int prevItemId, int nextItemId, ref Issue issue)
        {
            if (previousItem)
            {
                var prevIssue = _issuesEngine.GetIssue(prevItemId);
                issue.Order = prevIssue.Order + 1;
            }
            else
            {
                var nextIssue = _issuesEngine.GetIssue(nextItemId);
                issue.Order = nextIssue.Order - 1;
            }
        }

        public override void ReorderIssues(int currentItemIndex, ref Issue issue, ref List<Issue> issues)
        {
            for (var i = currentItemIndex; i < issues.Count; i++)
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
using System.Collections.Generic;
using DataAccess.Models;

namespace BussinessLogic.Logic
{
    /// <summary>
    /// The Drag drop strategy abstract class
    /// </summary>
    public abstract class DragDopStrategy
    {
        public abstract void DetermineNewIssueOrder(bool previousItem, int prevItemId, int nextItemId, ref Issue issue);
        public abstract void ReorderIssues(int currentItemIndex, ref Issue issue, ref List<Issue> issues);
    }
}
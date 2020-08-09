using System.Collections.Generic;
using DataAccess.Models;

namespace BussinessLogic.Logic
{
    /// <summary>
    /// The 'Context' class
    /// </summary>

    public class DragDropContext
    {
        private readonly DragDopStrategy _strategy;
 
        public DragDropContext(DragDopStrategy strategy)
        {
            this._strategy = strategy;
        }
 
        public void ReorderIssues(int currentItemIndex, ref Issue issue, ref List<Issue> issues)
        {
            _strategy.ReorderIssues(currentItemIndex, ref issue, ref issues);
        }
        
        public void DetermineNewIssueOrder(bool previousItem, int prevItemId, int nextItemId, ref Issue issue)
        {
            _strategy.DetermineNewIssueOrder(previousItem, prevItemId, nextItemId, ref issue);
        }
    }
}
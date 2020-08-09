using BussinessLogic.Logic;
using DataAccess.Interfaces;

namespace BussinessLogic.Factory
{
    public static class DragDropFactory
    {        
        public static DragDropContext GetDragDropManager(bool issueLiesInBottomHalf, IIssuesEngine issuesEngine)
        {
            DragDropContext obj = null;
            if (issueLiesInBottomHalf)
            {
                 obj = new DragDropContext(new DropItemToBottom(issuesEngine));
            }
            else
            {
                 obj = new DragDropContext(new DropItemToTop(issuesEngine));
            }
            return obj;
        }
    }
}

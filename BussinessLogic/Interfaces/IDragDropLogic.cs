using ServiceModel.Models;
using System.Collections.Generic;

namespace BussinessLogic.Interfaces
{
    public interface IDragDropLogic
    {
        List<Issue> DropItem(bool previtem, int prevItemId, int nextItemId, int currentItemIndex, Issue issue, List<Issue> issues);
    }
}

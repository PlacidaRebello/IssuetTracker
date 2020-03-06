using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLogic.Interfaces
{
    public interface IDragDropLogic
    {
        List<Issue> DropItem(bool previtem, int prevItemId, int nextItemId, int currentItemIndex, Issue issue, List<Issue> issues);
    }
}

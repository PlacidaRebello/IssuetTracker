using DataAccess.Models;
using System.Collections.Generic;

namespace BussinessLogic.Interfaces
{
    public interface IStatusLogic
    {
        int CreateStatus(Status status);
        Status GetStatusByName(string statusName);
        bool RemoveStatus(int id);
        Status GetStatus(int id);
        bool EditStatus(Status newStatus);
        List<Status> GetStatusList();
    }
}

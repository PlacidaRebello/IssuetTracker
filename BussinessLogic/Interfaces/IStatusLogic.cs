using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace BussinessLogic.Interfaces
{
    public interface IStatusLogic
    {
        int CreateStatus(Status status);
        Status GetStatusByName(string statusName);
        bool RemoveStatus(int id);
        Status GetStatus(int id);
        bool EditStatus(Status newStatus);
    }
}

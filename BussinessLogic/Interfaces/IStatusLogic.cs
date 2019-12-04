using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace BussinessLogic.Interfaces
{
    public interface IStatusLogic
    {
        Task<int> CreateStatus(Status status);
        Task<Status> GetStatusByName(string statusName);
        void RemoveStatus(int id);
        Status GetStatus(int id);
        void EditStatus(Status newStatus);
    }
}

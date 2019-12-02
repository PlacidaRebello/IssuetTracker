using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IStatusEngine
    {
        Task<int> CreateStatus(Status status);
        Task<Status> GetStatusByName(string statusName);
        void RemoveStatus(Status status);
        bool StatusExists(int id);

        Status GetStatus(int id);
        void EditStatus(Status newStatus);
    }
}

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
        Task<Status> GetStatusByName(string statusName);
    }
}

using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IStatusEngine
    {
        int CreateStatus(Status status);
        Task<Status> GetStatusByName(string statusName);
    }
}

using BussinessLogic.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic
{
    public class StatusLogic : IStatusLogic
    {
        private readonly IStatusEngine _statusEngine;
        public StatusLogic(IStatusEngine statusEngine)
        {
            _statusEngine = statusEngine;
        }
        public int CreateStatus(Status status)
        {
            throw new NotImplementedException();
        }

        public async Task<Status> GetStatusByName(string statusName)
        {
            return await _statusEngine.GetStatusByName(statusName);
        }
    }
}

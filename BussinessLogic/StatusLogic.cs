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
        public async Task<int> CreateStatus(Status status)
        {
            return await _statusEngine.CreateStatus(status);
        }

        public void EditStatus(Status newStatus)
        {
            if (!_statusEngine.StatusExists(newStatus.StatusId))
            {
                throw new Exception("Status Doesnot exists ");
            }
            _statusEngine.EditStatus(newStatus);
            
        }

        public Status GetStatus(int id)
        {
            return _statusEngine.GetStatus(id);
        }

        public async Task<Status> GetStatusByName(string statusName)
        {
            return await _statusEngine.GetStatusByName(statusName);
        }

        public void RemoveStatus(int id)
        {
            var status = _statusEngine.GetStatus(id);
            if (status== null)
            {
                throw new Exception("Status doesnot exists");
            }           

            _statusEngine.RemoveStatus(status);            

        }
    }
}

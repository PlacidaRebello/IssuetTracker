using BussinessLogic.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Models;
using System;

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
            return _statusEngine.CreateStatus(status);
        }

        public bool EditStatus(Status newStatus)
        {
            if (!_statusEngine.StatusExists(newStatus.StatusId))
            {
                throw new Exception("Status Doesnot exists ");
            }
            _statusEngine.EditStatus(newStatus);
            return true;
        }

        public Status GetStatus(int id)
        {
            return _statusEngine.GetStatus(id);
        }

        public Status GetStatusByName(string statusName)
        {
            return _statusEngine.GetStatusByName(statusName);
        }

        public bool RemoveStatus(int id)
        {
            var status = _statusEngine.GetStatus(id);
            if (status == null)
            {
                throw new Exception("Status doesnot exists");
            }
            _statusEngine.RemoveStatus(status);
            return true;
        }
    }
}

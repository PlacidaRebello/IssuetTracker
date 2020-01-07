using BussinessLogic.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;

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
            if (_statusEngine.StatusExists(status.StatusName))
            {
                throw new Exception("Status already exists ");
            }
            status.CreatedDate = DateTime.Now;
            return _statusEngine.CreateStatus(status);
        }

        public bool EditStatus(Status newStatus)
        {
            if (!_statusEngine.StatusExists(newStatus.StatusId))
            {
                throw new Exception("Status Doesnot exists ");
            }
            newStatus.CreatedDate = DateTime.Now;
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

        public List<Status> GetStatusList()
        {
            return _statusEngine.GetStatusList();
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

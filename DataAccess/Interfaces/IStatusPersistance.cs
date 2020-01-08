﻿using DataAccess.Models;
using System.Collections.Generic;

namespace DataAccess.Interfaces
{
    public interface IStatusPersistence
    {
        int CreateStatus(Status status);
        Status GetStatusByName(string statusName);
        bool RemoveStatus(Status status);
        bool StatusExists(string status);
        bool StatusExists(int id);
        Status GetStatus(int id);
        bool EditStatus(Status newStatus);
        List<Status> GetStatusList();
    }
}
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interfaces
{
    public interface ISprintEngine
    {
        int CreateSprint(Sprint sprint);
        Sprint GetSprint(int id);
        bool RemoveSprint(Sprint sprint);
        bool EditSprint(Sprint sprint);
        bool SprintExists(int id);
    }
}

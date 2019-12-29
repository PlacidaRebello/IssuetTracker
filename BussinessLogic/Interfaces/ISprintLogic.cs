using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLogic.Interfaces
{
    public interface ISprintLogic
    {
        int CreateSprint(Sprint sprint);
        bool RemoveSprint(int id);
        Sprint GetSprint(int id);
        bool EditSprint(Sprint sprint);
    }
}

using DataAccess.Models;
using System.Collections.Generic;

namespace DataAccess.Interfaces
{
    public interface ISprintPersistence
    {
        int CreateSprint(Sprint sprint);
        Sprint GetSprint(int id);
        bool RemoveSprint(Sprint sprint);
        bool EditSprint(Sprint sprint);
        bool SprintExists(int id);
        List<Sprint> GetSprints();
    }
}

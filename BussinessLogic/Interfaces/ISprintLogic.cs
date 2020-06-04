using ServiceModel.Models;
using System.Collections.Generic;

namespace BussinessLogic.Interfaces
{
    public interface ISprintLogic
    {
        int CreateSprint(Sprint sprint);
        bool RemoveSprint(int id);
        Sprint GetSprint(int id);
        bool EditSprint(Sprint sprint);
        List<Sprint> GetSprints();
        List<SprintStatus> GetSprintStatusList();
    }
}

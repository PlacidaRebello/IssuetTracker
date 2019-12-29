using BussinessLogic.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLogic
{
    public class SprintLogic : ISprintLogic
    {
        private readonly ISprintEngine _sprintEngine;
        public SprintLogic(ISprintEngine sprintEngine)
        {
            _sprintEngine = sprintEngine;
        }
        public int CreateSprint(Sprint sprint)
        {            
            sprint.SprintStatusId = 1;
            return _sprintEngine.CreateSprint(sprint);
        }

        public bool EditSprint(Sprint sprint)
        {
            if (!_sprintEngine.SprintExists(sprint.SprintId))
            {
                throw new Exception("Sprint does not exists");
            }
            return _sprintEngine.EditSprint(sprint);
        }

        public Sprint GetSprint(int id)
        {
            return _sprintEngine.GetSprint(id);
        }

        public List<Sprint> GetSprints()
        {
            return _sprintEngine.GetSprints();
        }

        public bool RemoveSprint(int id)
        {
            var sprint = _sprintEngine.GetSprint(id);
            if (sprint == null)
            {
                throw new Exception("Sprint does not exists");
            }
            return _sprintEngine.RemoveSprint(sprint);
        }
    }
}

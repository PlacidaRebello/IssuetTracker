using DataAccess.Interfaces;
using DataAccess.Models;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class SprintEngine : ISprintEngine
    {
        private readonly DataContext _context;
        public SprintEngine(DataContext context)
        {
            _context = context;
        }

        public int CreateSprint(Sprint sprint)
        {
            _context.Sprints.Add(sprint);
            _context.SaveChanges();
            return sprint.SprintId;
        }

        public bool EditSprint(Sprint sprint)
        {
            _context.Sprints.Update(sprint);
            _context.SaveChanges();
            return true;
        }

        public Sprint GetSprint(int id)
        {
            return _context.Sprints.FirstOrDefault(i => i.SprintId == id);
        }

        public List<Sprint> GetSprints()
        {
            return _context.Sprints.ToList<Sprint>();
        }

        public bool RemoveSprint(Sprint sprint)
        {
            _context.Sprints.Remove(sprint);
            _context.SaveChanges();
            return true;
        }

        public bool SprintExists(int id)
        {
            return _context.Sprints.Any(e => e.SprintId == id);
        }

        //getlist of statuses for dropdown
        public List<SprintStatus> GetSprintStatusList() 
        {
            return _context.SprintStatuses.ToList<SprintStatus>();
        }
    }
}

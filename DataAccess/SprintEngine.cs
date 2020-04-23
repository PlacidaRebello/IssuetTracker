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
            var sprint = (from SprintStatus in _context.SprintStatuses
                          join Sprint in _context.Sprints
                          on SprintStatus.SprintStatusId equals Sprint.SprintStatusId
                          where Sprint.SprintId==id
                          select new Sprint
                          {
                              SprintId = Sprint.SprintId,
                              SprintName = Sprint.SprintName,
                              SprintPoints = Sprint.SprintPoints,
                              StartDate = Sprint.StartDate,
                              EndDate = Sprint.EndDate,
                              SprintStatusId = Sprint.SprintStatusId,
                              ReleaseId=Sprint.ReleaseId
                          }).FirstOrDefault();
            return sprint;
        }

        public List<Sprint> GetSprints()
        {
            var sprintList = (from SprintStatus in _context.SprintStatuses
                              join Sprint in _context.Sprints
                              on SprintStatus.SprintStatusId equals Sprint.SprintStatusId
                              select new Sprint
                              {
                                  SprintId = Sprint.SprintId,
                                  SprintName = Sprint.SprintName,
                                  SprintPoints = Sprint.SprintPoints,
                                  StartDate = Sprint.StartDate,
                                  EndDate = Sprint.EndDate,
                                  SprintStatusId = Sprint.SprintStatusId,
                                  SprintStatusName = SprintStatus.SprintStatusName,
                                  ReleaseId=Sprint.ReleaseId
                              }).ToList();

            return sprintList;
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

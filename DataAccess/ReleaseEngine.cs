using DataAccess.Interfaces;
using DataAccess.Models;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class ReleaseEngine : IReleaseEngine
    {
        private readonly DataContext _context;
        public ReleaseEngine(DataContext context)
        {
            _context = context;
        }
        public int CreateRelease(Release release)
        {
            _context.Release.Add(release);
            _context.SaveChanges();
            return release.ReleaseId;
        }
        public bool EditRelease(Release release)
        {
            _context.Release.Update(release);
            _context.SaveChanges();
            return true;
        }
        public Release GetRelease(int id)
        {
            var release = (from SprintStatus in _context.SprintStatuses
                               join Release in _context.Release
                               on SprintStatus.SprintStatusId equals Release.SprintStatusId
                               where Release.ReleaseId==id
                               select new Release
                               {
                                   ReleaseId = Release.ReleaseId,
                                   ReleaseName = Release.ReleaseName,
                                   StartDate = Release.StartDate,
                                   EndDate = Release.EndDate,
                                   SprintStatusId = Release.SprintStatusId,
                                   SprintStatusName = SprintStatus.SprintStatusName
                               }).FirstOrDefault();

            return release;
        }
        public List<Release> GetReleaseList()
        {
            var releaseList = (from SprintStatus in _context.SprintStatuses
                        join Release in _context.Release
                        on SprintStatus.SprintStatusId equals Release.SprintStatusId
                        select new Release
                        {
                           ReleaseId=Release.ReleaseId,
                           ReleaseName=Release.ReleaseName,
                           StartDate=Release.StartDate,
                           EndDate=Release.EndDate,
                           SprintStatusId=Release.SprintStatusId,
                           SprintStatusName=SprintStatus.SprintStatusName
                        }).ToList();

            return releaseList;
        }
        public bool ReleaseExists(int id)
        {
            return _context.Release.Any(i => i.ReleaseId == id);
        }
        public bool RemoveRelease(Release release)
        {
            _context.Release.Remove(release);
            _context.SaveChanges();
            return true;
        }
    }
}

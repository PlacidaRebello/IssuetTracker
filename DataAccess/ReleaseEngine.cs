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
            return _context.Release.FirstOrDefault(i => i.ReleaseId == id);
        }
        public List<Release> GetReleaseList()
        {
            return _context.Release.ToList<Release>();
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

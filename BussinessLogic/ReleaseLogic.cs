using BussinessLogic.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;

namespace BussinessLogic
{
    public class ReleaseLogic : IReleaseLogic
    {
        private readonly IReleasePersistence _releaseEngine;
        public ReleaseLogic(IReleasePersistence releaseEngine)
        {
            _releaseEngine = releaseEngine;
        }

        public int CreateRelease(Release release)
        {
            release.SprintStatusId = 1;
            release.CreatedDate = DateTime.Now;
            return _releaseEngine.CreateRelease(release);
        }

        public bool EditRelease(Release release)
        {
            if (!_releaseEngine.ReleaseExists(release.ReleaseId))
            {
                throw new Exception("Release does not exists");
            }
            release.CreatedDate = DateTime.Now;
            return _releaseEngine.EditRelease(release);
        }

        public Release GetRelease(int id)
        {
            return _releaseEngine.GetRelease(id);
        }

        public List<Release> GetReleaseList()
        {
            return _releaseEngine.GetReleaseList();
        }

        public bool RemoveRelease(int id)
        {
            var release = _releaseEngine.GetRelease(id);
            if (release == null)
            {
                throw new Exception("Release does not exists");
            }
            return _releaseEngine.RemoveRelease(release);
        }
    }
}

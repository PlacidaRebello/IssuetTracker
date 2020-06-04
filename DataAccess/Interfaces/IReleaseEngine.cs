using ServiceModel.Models;
using System.Collections.Generic;

namespace DataAccess.Interfaces
{
    public interface IReleaseEngine
    {
        int CreateRelease(Release release);
        Release GetRelease(int id);
        bool RemoveRelease(Release release);
        bool EditRelease(Release release);
        List<Release> GetReleaseList();
        bool ReleaseExists(int id);
    }
}

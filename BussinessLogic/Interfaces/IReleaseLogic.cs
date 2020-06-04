using ServiceModel.Models;
using System.Collections.Generic;

namespace BussinessLogic.Interfaces
{
    public interface IReleaseLogic
    {
        int CreateRelease(Release release);
        Release GetRelease(int id);
        bool RemoveRelease(int id);
        bool EditRelease(Release release);
        List<Release> GetReleaseList();
    }
}

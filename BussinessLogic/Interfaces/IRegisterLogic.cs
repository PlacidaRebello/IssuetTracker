using DataAccess.DataModels;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BussinessLogic.Interfaces
{
    public interface IRegisterLogic
    {
        Task<AppUser> CheckIfUserExists(string userName);
        void CheckIfRolesExistsElseCreate();
        Task<IdentityResult> CreateUser(AppUser user, string modelPassword);
    }
}

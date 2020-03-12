using DataAccess.DataModels;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BussinessLogic.Interfaces
{
    public interface IRegisterLogic
    {
        Task<IdentityResult> RegisterUser(AppUser user, string password);
    }
}

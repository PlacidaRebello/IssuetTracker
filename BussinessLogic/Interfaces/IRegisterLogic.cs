using DataAccess.Models;
using System.Threading.Tasks;

namespace BussinessLogic.Interfaces
{
    public interface IRegisterLogic
    {
        Task<bool> RegisterUser(AppUser user, string password);
    }
}

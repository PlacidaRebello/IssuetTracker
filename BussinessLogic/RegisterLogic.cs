using BussinessLogic.Interfaces;
using DataAccess.DataModels;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BussinessLogic
{
    public class RegisterLogic : IRegisterLogic
    {
        private UserManager<IdentityUser> _userManager { get; }
        public RegisterLogic(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> RegisterUser(AppUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);            
        }
    }
}

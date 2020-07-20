using BussinessLogic.Interfaces;
using DataAccess.DataModels;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BussinessLogic
{
    public class RegisterLogic : IRegisterLogic
    {
        private UserManager<AppUser> _userManager { get; }
        private readonly IUsersEngine _userEngine;
        public RegisterLogic(UserManager<AppUser> userManager, IUsersEngine userEngine) 
        {
            _userManager = userManager;
            _userEngine = userEngine;
        }

        //public async Task<IdentityResult> RegisterUser(AppUser user, string password)
        //{
        //    return await _userManager.CreateAsync(user, password);            
        //}

        public async Task<AppUser> CheckIfUserExists(string userName)
        {
            return await _userEngine.CheckIfUserExists(userName);
        }
        public void CheckIfRolesExistsElseCreate()
        {
             _userEngine.CheckIfRolesExistsElseCreate();
        }
    }
}

using BussinessLogic.Interfaces;
using DataAccess.DataModels;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BussinessLogic
{
    public class RegisterLogic : IRegisterLogic
    {
        private readonly IUsersEngine _userEngine;
        public RegisterLogic( IUsersEngine userEngine) 
        {
            _userEngine = userEngine;
        }

        public async Task<AppUser> CheckIfUserExists(string userName)
        {
            return await _userEngine.CheckIfUserExists(userName);
        }
        public async Task CheckIfRolesExistsElseCreate()
        {
             await _userEngine.CheckIfRolesExistsElseCreate();
        }

        public async Task<IdentityResult> CreateUser(AppUser user, string password)
        {
            return await _userEngine.CreateAsync(user, password);
        }

        public async Task AssignRoleToUser(string userRole, AppUser user)
        {
           await  _userEngine.AssignRoleToUser(userRole,user);
        }
    }
}

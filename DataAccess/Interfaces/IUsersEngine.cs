using DataAccess.DataModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IUsersEngine
    {
        List<AppUser> GetUsers();
        Task<AppUser> CheckIfUserExists(string userName);
        Task CheckIfRolesExistsElseCreate();
        Task<IdentityResult> CreateAsync(AppUser user, string password);
        Task AssignRoleToUser(string userRole, AppUser user);
    }
}

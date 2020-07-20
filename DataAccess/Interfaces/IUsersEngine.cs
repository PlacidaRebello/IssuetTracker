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
        List<AppUser> getUsers();
        Task<AppUser> CheckIfUserExists(string userName);
        void CheckIfRolesExistsElseCreate();
    }
}

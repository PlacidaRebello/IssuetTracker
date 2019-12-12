using DataAccess.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RegisterEngine : IRegisterEngine
    {
        public RegisterEngine(UserManager<IdentityUser> userManager)
        {
            UserManager = userManager;
        }

        public UserManager<IdentityUser> UserManager { get; }

        public async Task<bool> RegisterUser(IdentityUser identityUser,string password)
        {
          var result= await UserManager.CreateAsync(identityUser, password);
            return result.Succeeded;  
        }
    }
}

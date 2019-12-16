using BussinessLogic.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
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

        public async Task<bool> RegisterUser(AppUser user, string password)
        {
            //bool result= await  _registerEngine.RegisterUser(identityUser, password);
            // return result;
            var result = await _userManager.CreateAsync(user, password);
            return result.Succeeded;
        }
    }
}

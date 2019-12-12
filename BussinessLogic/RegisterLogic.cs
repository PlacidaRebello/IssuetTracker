using BussinessLogic.Interfaces;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic
{
    public class RegisterLogic : IRegisterLogic
    {
        private readonly IRegisterEngine _registerEngine;
        public RegisterLogic(IRegisterEngine registerEngine)
        {
            _registerEngine = registerEngine;
        }
        public async Task<bool> RegisterUser(IdentityUser identityUser,string password)
        {
           bool result= await  _registerEngine.RegisterUser(identityUser, password);
            return result;  
        }
    }
}

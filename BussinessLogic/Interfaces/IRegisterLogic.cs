using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Interfaces
{
    public interface IRegisterLogic
    {
        Task<bool> RegisterUser(IdentityUser identityUser,string password);
    }
}

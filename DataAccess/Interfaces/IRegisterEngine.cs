using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IRegisterEngine
    {
         Task<bool> RegisterUser(IdentityUser identityUser,string password);
    }
}

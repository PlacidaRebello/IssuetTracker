using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BussinessLogic.Interfaces
{
    public interface IUsersLogic
    {
        List<IdentityUser> GetIdentityUsers();
    }
}

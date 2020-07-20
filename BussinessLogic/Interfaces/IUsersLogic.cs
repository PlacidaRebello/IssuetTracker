using DataAccess.DataModels;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BussinessLogic.Interfaces
{
    public interface IUsersLogic
    {
        List<AppUser> GetIdentityUsers();
    }
}

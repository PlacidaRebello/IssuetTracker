using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using ServiceModel.Models;

namespace DataAccess.Interfaces
{
    public interface IUsersEngine
    {
        List<IdentityUser> getUsers();
    }
}

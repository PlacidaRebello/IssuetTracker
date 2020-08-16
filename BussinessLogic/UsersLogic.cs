using BussinessLogic.Interfaces;
using DataAccess.DataModels;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BussinessLogic
{
    public class UsersLogic:IUsersLogic
    {
        private readonly IUsersEngine _usersEngine;
        public UsersLogic(IUsersEngine usersEngine)
        {
            _usersEngine = usersEngine;
        }
        public List<AppUser> GetIdentityUsers()
        {
            return _usersEngine.GetUsers();
        }
    }
}

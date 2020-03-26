using BussinessLogic.Interfaces;
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
        public List<IdentityUser> GetIdentityUsers()
        {
            return _usersEngine.getUsers();
        }
    }
}

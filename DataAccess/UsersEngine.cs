using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class UsersEngine:IUsersEngine
    {
        private readonly DataContext _context;
        public UsersEngine(DataContext context)
        { 
            _context = context;
        }
        public List<IdentityUser> getUsers()
        {
            return _context.Users.ToList();
        }
    }
}

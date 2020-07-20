using DataAccess.DataModels;
using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UsersEngine:IUsersEngine
    {
        private readonly DataContext _context;
        private UserManager<AppUser> _userManager { get; }
        public readonly RoleManager<IdentityRole> _roleManager;
        public UsersEngine(DataContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        { 
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<AppUser> CheckIfUserExists(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }

        public List<AppUser> getUsers()
        {
            return _context.Users.ToList();
        }

        public async void CheckIfRolesExistsElseCreate()
        {
            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await _roleManager.RoleExistsAsync(UserRoles.Developer))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Developer));
        }
    }
}

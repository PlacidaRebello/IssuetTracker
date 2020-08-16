using BussinessLogic.Interfaces;
using DataAccess.DataModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiceModel.Dto;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System;
using Microsoft.AspNetCore.Http;

namespace IssueTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        public readonly UserManager<AppUser> userManager;
        public readonly RoleManager<IdentityRole> roleManager;
        public readonly IConfiguration _configuration;
        private readonly IRegisterLogic _registerLogic;
        private readonly IUsersLogic _usersLogic;

        public RegisterController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager,
            IConfiguration configuration, IRegisterLogic registerLogic, IUsersLogic usersLogic)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
            _registerLogic = registerLogic;
            _usersLogic = usersLogic;
        }

        [HttpPost]
        [Route("register")]
        public async Task<SuccessResponse> Register([FromBody] RegisterUserRequest model)
        {
            var userExists = await _registerLogic.CheckIfUserExists(model.UserName);
            if (userExists != null)
                return new SuccessResponse {  Message = "User already exists!" };

            AppUser user = new AppUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return new SuccessResponse { Message = "User creation failed! Please check user details and try again." };

            _registerLogic.CheckIfRolesExistsElseCreate();
            AssignRoleToUser(model.UserRole,user);

            return new SuccessResponse {  Message = "User created successfully!" };
        }

        private async void AssignRoleToUser(string UserRole,AppUser user) 
        {
            if (UserRole == UserRoles.Admin)
            {
                await userManager.AddToRoleAsync(user, UserRoles.Admin);
            }
            else
            {
                await userManager.AddToRoleAsync(user, UserRoles.Developer);
            }
        }

        [HttpGet("Users")]
        public List<GetUsersData> GetUsers()
        {
            var users = _usersLogic.GetIdentityUsers();
            List<GetUsersData> usersList = new List<GetUsersData>();
            foreach (var user in users)
            {
                var newUser = new GetUsersData();
                newUser.Id = user.Id;
                newUser.Username = user.UserName;
                usersList.Add(newUser);
            }
            return usersList;
        }
    }
}
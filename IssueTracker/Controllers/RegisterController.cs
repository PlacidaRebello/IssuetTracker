using AutoMapper;
using BussinessLogic.Interfaces;
using DataAccess.DataModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiceModel.Dto;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace IssueTracker.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private SignInManager<IdentityUser> _signInManager { get; }
        private readonly IRegisterLogic _registerLogic;
        private readonly IMapper _mapper;

        private readonly IUsersLogic _usersLogic;
        public RegisterController(SignInManager<IdentityUser> signInManager, IMapper mapper, IRegisterLogic registerLogic,IUsersLogic usersLogic)
        {
            _signInManager = signInManager;
            _mapper = mapper;
            _registerLogic = registerLogic;
            _usersLogic = usersLogic;
        }

        [HttpPost]
        public async Task<SuccessResponse> CreateUserAsync(RegisterUserRequest userRequest)
        {
            var newUser = _mapper.Map<AppUser>(userRequest);
            var result = await _registerLogic.RegisterUser(newUser, userRequest.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(newUser, isPersistent: false);//cookies shoulnot persist after browser is closed
                return new SuccessResponse { Message = "Registered Succesfully." };
            }

            return new SuccessResponse { Message = result.Errors.FirstOrDefault()?.Description};
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
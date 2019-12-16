using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceModel.Dto;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using BussinessLogic.Interfaces;
using DataAccess.Models;

namespace IssueTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        public UserManager<IdentityUser> UserManager { get; }
        private SignInManager<IdentityUser> _signInManager { get; }

        private readonly IRegisterLogic _registerLogic;

        private readonly IMapper _mapper;
        public RegisterController(UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager, IMapper mapper,IRegisterLogic registerLogic)
        {
            this.UserManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _registerLogic = registerLogic;
        }


        //not created a response class yet
        [HttpPost]
        public async Task<CreateIssueResponse> CreateUserAsync(RegisterUserRequest userRequest) 
        {
            var newuser = _mapper.Map<AppUser>(userRequest);
            bool result=await _registerLogic.RegisterUser(newuser,userRequest.Password);

            if (result)
            {
                await _signInManager.SignInAsync(newuser, isPersistent: false);//cookies shoulnot persist after browser is closed
                 return  new CreateIssueResponse{Message="registered",IssueId=1};
            }
            return  new CreateIssueResponse{Message="try again"};
        }
    }
}
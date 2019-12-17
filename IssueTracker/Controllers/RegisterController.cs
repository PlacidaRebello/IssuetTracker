﻿using System;
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
        private SignInManager<IdentityUser> _signInManager { get; }
        private readonly IRegisterLogic _registerLogic;
        private readonly IMapper _mapper;
        public RegisterController( SignInManager<IdentityUser> signInManager, IMapper mapper, IRegisterLogic registerLogic)
        {
            _signInManager = signInManager;
            _mapper = mapper;
            _registerLogic = registerLogic;
        }

        [HttpPost]
        public async Task<CreateResponse> CreateUserAsync(RegisterUserRequest userRequest)
        {
            var newUser = _mapper.Map<AppUser>(userRequest);
            bool result = await _registerLogic.RegisterUser(newUser, userRequest.Password);
            if (result)
            {
                await _signInManager.SignInAsync(newUser, isPersistent: false);//cookies shoulnot persist after browser is closed
                return new CreateResponse { Message = "registered", Id = 1 };
            }
            return new CreateResponse { Message = "try again" };
        }
    }
}
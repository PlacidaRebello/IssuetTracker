﻿using AutoMapper;
using BussinessLogic.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceModel.Dto;
using System.Collections.Generic;

namespace IssueTracker.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReleasesController : ControllerBase
    {
        private readonly IReleaseLogic _releaseLogic;
        private readonly IMapper _mapper;
        public ReleasesController(IReleaseLogic releaseLogic, IMapper mapper)
        {
            _releaseLogic = releaseLogic;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<GetReleaseData> GetReleaseList()
        {
            List<Release> release = _releaseLogic.GetReleaseList();
            List<GetReleaseData> releaseList = _mapper.Map<List<Release>, List<GetReleaseData>>(release);
            return releaseList;
        }

        [HttpGet("{id}")]
        public GetReleaseData GetRelease(int id)
        {
            var release = _releaseLogic.GetRelease(id);
            GetReleaseData getRelease = _mapper.Map<Release, GetReleaseData>(release);
            return getRelease;
        }

        [HttpPut]
        public SuccessResponse PutRelease(int id, EditReleaseRequest release)
        {
            var newRelease = _mapper.Map<Release>(release);
            _releaseLogic.EditRelease(newRelease);
            return new SuccessResponse
            {
                Message = "Edited Succesfully"
            };
        }

        [HttpPost]
        public SuccessResponse PostRelease(CreateReleaseRequest release)
        {
            var newRelease = _mapper.Map<Release>(release);
            var releaseId = _releaseLogic.CreateRelease(newRelease);
            return new SuccessResponse
            {
                Id = releaseId,
                Message = "Release Created Successfully"
            };
        }

        [HttpDelete("{id}")]
        public SuccessResponse DeleteRelease(int id)
        {
            _releaseLogic.RemoveRelease(id);
            return new SuccessResponse
            {
                Id = id,
                Message = "Deleted Succesfully"
            };
        }
    }
}
using AutoMapper;
using BussinessLogic.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceModel.Dto;
using System.Collections.Generic;

namespace SprintTracker.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SprintsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISprintLogic _sprintLogic;
        public SprintsController(IMapper mapper, ISprintLogic sprintLogic)
        {
            _mapper = mapper;
            _sprintLogic = sprintLogic;
        }

        [HttpGet]
        public IEnumerable<GetSprintData> GetSprints()
        {
            List<Sprint> Sprints = _sprintLogic.GetSprints();
            List<GetSprintData> list = _mapper.Map<List<Sprint>, List<GetSprintData>>(Sprints);
            return list;
        }

        [HttpGet("{id}")]
        public GetSprintData GetSprint(int id)
        {
            var Sprint = _sprintLogic.GetSprint(id);
            GetSprintData getSprint = _mapper.Map<Sprint, GetSprintData>(Sprint);
            return getSprint;
        }

        [HttpPut]
        public SuccessResponse PutSprint(EditSprintRequest sprint)
        {
            var newSprint = _mapper.Map<Sprint>(sprint);
            _sprintLogic.EditSprint(newSprint);
            return new SuccessResponse
            {
                Message = "Sprint Edited Succesfully"
            };
        }

        [HttpPost]
        public SuccessResponse PostSprint(CreateSprintRequest sprint)
        {
            var newSprint = _mapper.Map<Sprint>(sprint);
            var SprintId = _sprintLogic.CreateSprint(newSprint);
            return new SuccessResponse
            {
                Id = SprintId,
                Message = "Sprint Created Successfully"
            };
        }

        [HttpDelete("{id}")]
        public SuccessResponse DeleteSprint(int id)
        {
            _sprintLogic.RemoveSprint(id);
            return new SuccessResponse
            {
                Id = id,
                Message = "Sprint Deleted Succesfully"
            };
        }

        [HttpGet]
        [Route("GetSprintStatus")]
        public IEnumerable<GetSprintStatusData> GetSprintStatusList()
        {
            List<SprintStatus> sprintStatus = _sprintLogic.GetSprintStatusList();
            List<GetSprintStatusData> list = _mapper.Map<List<SprintStatus>, List<GetSprintStatusData>>(sprintStatus);
            return list;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccess.Models;
using ServiceModel.Dto;
using AutoMapper;
using BussinessLogic.Interfaces;

namespace SprintTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SprintsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISprintLogic _sprintLogic;
        public SprintsController(IMapper mapper,ISprintLogic sprintLogic)
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

        [HttpPut("{id}")]
        public CreateResponse PutSprint(EditSprintRequest sprint)
        {
            var newSprint = _mapper.Map<Sprint>(sprint);
            _sprintLogic.EditSprint(newSprint);
            return new CreateResponse
            {
                Message = "Edited Succesfully"
            };
        }

        [HttpPost]
        public CreateResponse PostSprint(CreateSprintRequest sprint)
        {
            var newSprint = _mapper.Map<Sprint>(sprint);
            //newSprint.SprintStatusId = 1;
            var SprintId = _sprintLogic.CreateSprint(newSprint);
            return new CreateResponse
            {
                Id = SprintId,
                Message = "Sprint Created Successfully"
            };
        }

        [HttpDelete("{id}")]
        public CreateResponse DeleteSprint(int id)
        {
            _sprintLogic.RemoveSprint(id);
            return new CreateResponse
            {
                Id = id,
                Message = "Deleted Succesfully"
            };
        }
    }
}

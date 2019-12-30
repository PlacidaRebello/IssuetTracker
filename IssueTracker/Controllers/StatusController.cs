using AutoMapper;
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
    public class StatusController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IStatusLogic _statusLogic;

        public StatusController(IMapper mapper, IStatusLogic statusLogic)
        {
            _mapper = mapper;
            _statusLogic = statusLogic;
        }

        [HttpGet]
        public IEnumerable<GetStatusData> GetStatusList()
        {
            List<Status> status = _statusLogic.GetStatusList();
            List<GetStatusData> statusList = _mapper.Map<List<Status>, List<GetStatusData>>(status);
            return statusList;
        }

        [HttpGet("{id}")]
        public GetStatusData GetStatus(int id)
        {
            var status = _statusLogic.GetStatus(id);
            GetStatusData getStatus = _mapper.Map<Status, GetStatusData>(status);
            return getStatus;
        }

        [HttpPut]
        public CreateResponse PutStatus(EditStatusRequest status)
        {
            var newStatus = _mapper.Map<Status>(status);
            _statusLogic.EditStatus(newStatus);
            return new CreateResponse
            {
                Id = newStatus.StatusId,
                Message = "Edited Successfully"
            };
        }

        [HttpPost]
        public CreateResponse PostStatus(CreateStatusRequest status)
        {
            var newStatus = _mapper.Map<Status>(status);
            var statusId = _statusLogic.CreateStatus(newStatus);
            return new CreateResponse
            {
                Id = statusId,
                Message = "Issue Created Successfully"
            };
        }

        [HttpDelete("{id}")]
        public CreateResponse DeleteStatus(int id)
        {
            _statusLogic.RemoveStatus(id);
            return new CreateResponse
            {
                Id = id,
                Message = "Deleted Succesfully"
            };
        }
    }
}

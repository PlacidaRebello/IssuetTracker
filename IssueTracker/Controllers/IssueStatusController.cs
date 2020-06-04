using AutoMapper;
using BussinessLogic.Interfaces;
using ServiceModel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceModel.Dto;
using System.Collections.Generic;

namespace IssueTracker.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class IssueStatusController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IIssueStatusLogic _issueStatusLogic;

        public IssueStatusController(IMapper mapper, IIssueStatusLogic issueStatusLogic)
        {
            _mapper = mapper;
            _issueStatusLogic = issueStatusLogic;
        }

        [HttpGet]
        public IEnumerable<GetIssueStatusData> GetStatusList()
        {
            List<IssueStatus> status = _issueStatusLogic.GetStatusList();
            List<GetIssueStatusData> statusList = _mapper.Map<List<IssueStatus>, List<GetIssueStatusData>>(status);
            return statusList;
        }

        [HttpGet("{id}")]
        public GetIssueStatusData GetStatus(int id)
        {
            var status = _issueStatusLogic.GetStatus(id);
            GetIssueStatusData getStatus = _mapper.Map<IssueStatus, GetIssueStatusData>(status);
            return getStatus;
        }

        [HttpPut]
        public SuccessResponse PutStatus(EditIssueStatusRequest status)
        {
            var newStatus = _mapper.Map<IssueStatus>(status);
            _issueStatusLogic.EditStatus(newStatus);
            return new SuccessResponse
            {
                Id = newStatus.IssueStatusId,
                Message = "Edited Successfully"
            };
        }

        [HttpPost]
        public SuccessResponse PostStatus(CreateIssueStatusRequest status)
        {
            var newStatus = _mapper.Map<IssueStatus>(status);
            var statusId = _issueStatusLogic.CreateStatus(newStatus);
            return new SuccessResponse
            {
                Id = statusId,
                Message = "Issue Created Successfully"
            };
        }

        [HttpDelete("{id}")]
        public SuccessResponse DeleteStatus(int id)
        {
            _issueStatusLogic.RemoveStatus(id);
            return new SuccessResponse
            {
                Id = id,
                Message = "Deleted Succesfully"
            };
        }

       
    }
}

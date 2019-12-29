using AutoMapper;
using BussinessLogic.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceModel.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IssueTracker.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class IssueTypesController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IIssueTypeLogic _issueTypeLogic;
        public IssueTypesController(DataContext context, IMapper mapper, IIssueTypeLogic issueTypeLogic)
        {
            _context = context;
            _mapper = mapper;
            _issueTypeLogic = issueTypeLogic;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IssueType>>> GetIssueType()
        {
            return await _context.IssueType.ToListAsync();
        }

        [HttpGet("{id}")]
        public GetIssueTypeData GetIssueType(int id)
        {
            var issueType = _issueTypeLogic.GetIssueType(id);
            GetIssueTypeData issueTypeData = _mapper.Map<IssueType, GetIssueTypeData>(issueType);
            return issueTypeData;
        }

        [HttpPut]
        public CreateResponse PutIssueType(EditIssueTypeRequest issueType)
        {
            var newIssueType = _mapper.Map<IssueType>(issueType);
            _issueTypeLogic.EditIssueType(newIssueType);
            return new CreateResponse
            {
                Id = newIssueType.IssueTypeId,
                Message = "Edited Successfully"
            };
        }

        [HttpPost]
        public CreateResponse PostIssueType(CreateIssueTypeRequest issueType)
        {
            var newIssueType = _mapper.Map<IssueType>(issueType);
            newIssueType.CreatedDate = DateTime.Now;
            var issueTypeId = _issueTypeLogic.CreateIssueType(newIssueType);
            return new CreateResponse
            {
                Id = issueTypeId,
                Message = "IssueType Created Successfully"
            };
        }

        [HttpDelete("{id}")]
        public CreateResponse DeleteIssueType(int id)
        {
            _issueTypeLogic.RemoveIssueType(id);
            return new CreateResponse
            {
                Id = id,
                Message = "Deleted Successfully"
            };
        }
    }
}

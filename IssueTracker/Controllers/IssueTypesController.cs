using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccess.Models;
using AutoMapper;
using BussinessLogic.Interfaces;
using ServiceModel.Dto;

namespace IssueTracker.Controllers
{
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

        // GET: api/IssueTypes
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


        [HttpPut("{id}")]
        public CreateIssueTypeResponse PutIssueType(int id, EditIssueTypeRequest issueType)
        {
            var newIssueType = _mapper.Map<IssueType>(issueType);

            _issueTypeLogic.EditIssueType(id, newIssueType);

            return new CreateIssueTypeResponse
            {
                IssueTypeId = id,
                Message = "Edited successfully"
            };
        }


        [HttpPost]
        public async Task<CreateIssueTypeResponse> PostIssueType(CreateIssueTypeRequest issueType)
        {
            var newIssueType = _mapper.Map<IssueType>(issueType);
            newIssueType.CreatedDate = DateTime.Now;
            var issueTypeId = await _issueTypeLogic.CreateIssueType(newIssueType);

            return new CreateIssueTypeResponse
            {
                IssueTypeId = issueTypeId,
                Message = "Issue Created Successfully"
            };
        }


        [HttpDelete("{id}")]
        public CreateIssueTypeResponse DeleteIssueType(int id)
        {
            _issueTypeLogic.RemoveIssueType(id);

            return new CreateIssueTypeResponse
            {
                IssueTypeId = id,
                Message = "Deleted successfully"
            };
        }

        //private bool IssueTypeExists(int id)
        //{
        //    return _context.IssueType.Any(e => e.IssueTypeId == id);
        //}
    }
}

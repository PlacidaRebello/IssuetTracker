using AutoMapper;
using BussinessLogic.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceModel.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IssueTracker.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IStatusLogic _statusLogic;

        public StatusController(DataContext context, IMapper mapper, IStatusLogic statusLogic)
        {
            _context = context;
            _mapper = mapper;
            _statusLogic = statusLogic;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Status>>> GetStatus()
        {
            return await _context.Status.ToListAsync();
        }

        [HttpGet("{id}")]
        public GetStatusData GetStatus(int id)
        {
            var status = _statusLogic.GetStatus(id);
            GetStatusData getStatus = _mapper.Map<Status, GetStatusData>(status);
            return getStatus;
        }

        [HttpPut("{id}")]
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

        private bool StatusExists(int id)
        {
            return _context.Status.Any(e => e.StatusId == id);
        }
    }
}

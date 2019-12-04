using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceModel.Dto;
using DataAccess.Models;
using AutoMapper;
using BussinessLogic.Interfaces;

namespace IssueTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IStatusLogic _statusLogic;

        public StatusController(DataContext context,IMapper mapper,IStatusLogic statusLogic)
        {
            _context = context;
            _mapper = mapper;
            _statusLogic = statusLogic;
        }

        // GET: api/Status
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Status>>> GetStatus()
        {
            return await _context.Status.ToListAsync();
        }

       
        [HttpGet("{id}")]
        public  GetStatusData  GetStatus(int id)
        {
            var status = _statusLogic.GetStatus(id);
            // _mapper.Map<Status, GetStatusData>(status);
            GetStatusData getStatus = _mapper.Map<Status, GetStatusData>(status);
           
            return getStatus;
         
        }

        [HttpPut("{id}")]
        public CreateStatusResponse PutStatus(EditStatusRequest status)
        {
            var newStatus = _mapper.Map<Status>(status);

            _statusLogic.EditStatus(newStatus);

            return new CreateStatusResponse
            { StatusId = newStatus.StatusId,
              Message="Edited"
            };
        }

    
        [HttpPost]
        public async Task<CreateStatusResponse> PostStatus(CreateStatusRequest status)
        {
             var newStatus = _mapper.Map<Status>(status);

            var statusId = await _statusLogic.CreateStatus(newStatus);

            return new CreateStatusResponse
            {
                StatusId = statusId,
                Message = "Issue Created Successfully"
            };            
        }

        // DELETE: api/Status/5
        [HttpDelete("{id}")]
        public CreateStatusResponse DeleteStatus(int id)
        {
            _statusLogic.RemoveStatus(id);
            return new CreateStatusResponse
            {
                StatusId = id,
                Message = "Deleted Succesfully"
            };           
        }

        private bool StatusExists(int id)
        {
            return _context.Status.Any(e => e.StatusId == id);
        }
    }
}

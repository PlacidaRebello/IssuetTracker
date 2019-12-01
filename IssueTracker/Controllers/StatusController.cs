using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IssueTracker.Models;
using ServiceModel.Dto;

namespace IssueTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly DataContext _context;

        public StatusController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Status
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Status>>> GetStatus()
        {
            return await _context.Status.ToListAsync();
        }

        // GET: api/Status/5
        [HttpGet("{id}")]
        public async Task<GetStatusData> GetStatus(int id)
        {
          var status = await _context.Status.FindAsync(id);                      
        
            //if (status == null)
            //{
            //    return NotFound();
            //}

            return new GetStatusData {
                StatusName = status.StatusName,
                StatusId=status.StatusId,
                CreatedBy=status.CreatedBy
            };
        }

        [HttpPut("{id}")]
        public async Task<CreateStatusResponse> PutStatus(int id, CreateStatusRequest status)
        {
           
            Status getStatus = _context.Set<Status>().SingleOrDefault(c => c.StatusId == id);

            if (getStatus!=null)
            {
                getStatus.StatusName = status.StatusName;
                getStatus.CreatedBy = status.CreatedBy;
                _context.Entry(getStatus).State = EntityState.Modified;
            }            

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusExists(id))
                {
                   // return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return new CreateStatusResponse
            { StatusId = id,
              Message="Edited"
            };
        }

    
        [HttpPost]
        public async Task<CreateStatusResponse> PostStatus(CreateStatusRequest status)
        {
            //_context.Status.Add(status);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetStatus", new { id = status.StatusId }, status);

            var newStatus = new Status();
            newStatus.StatusName = status.StatusName;
            newStatus.CreatedBy = status.CreatedBy;
            newStatus.CreatedDate = DateTime.Now;

            _context.Status.Add(newStatus);
            await _context.SaveChangesAsync();

            return new CreateStatusResponse
            {
                StatusId = newStatus.StatusId,
                Message = "Status created successfully"
            };
        }

        // DELETE: api/Status/5
        [HttpDelete("{id}")]
        public async Task<CreateStatusResponse> DeleteStatus(int id)
        {
            Status status = _context.Set<Status>().SingleOrDefault(c => c.StatusId == id);

            if (status!=null)
            {
                _context.Entry(status).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;

            }
            await  _context.SaveChangesAsync();

            return new CreateStatusResponse
            {
                StatusId = id,
                Message = "Deleted Succesfully"
            };

            //var status = await _context.Status.FindAsync(id);
            //if (status == null)
            //{
            //    return NotFound();
            //}

            //_context.Status.Remove(status);
            //await _context.SaveChangesAsync();
          //  return status;
        }

        private bool StatusExists(int id)
        {
            return _context.Status.Any(e => e.StatusId == id);
        }
    }
}

using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class StatusEngine : IStatusEngine
    {
        private readonly DataContext _context;
        public StatusEngine(DataContext context)
        {
            _context = context;
        }

        public int CreateStatus(Status status)
        {
            throw new NotImplementedException();
        }

        public async Task<Status> GetStatusByName(string statusName)
        {
            return await _context.Status.FirstOrDefaultAsync(s => s.StatusName == statusName);
        }
    }
}

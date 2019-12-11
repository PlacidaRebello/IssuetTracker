﻿using DataAccess.Interfaces;
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
            _context.Status.Add(status);
            _context.SaveChanges();
            return status.StatusId;
        }

        public bool EditStatus(Status newStatus)
        {

            _context.Status.Update(newStatus);
            _context.SaveChanges();
            return true;
        }

        public Status GetStatus(int id)
        {
            return _context.Status.FirstOrDefault(s => s.StatusId == id);
        }

        public Status GetStatusByName(string statusName)
        {
            return _context.Status.FirstOrDefault(s => s.StatusName == statusName);
        }

        public bool RemoveStatus(Status status)
        {
            //var status = _context.Status.Find(id);

            _context.Status.Remove(status);
            _context.SaveChanges();
            return true;
        }

        public bool StatusExists(int id)
        {
            return _context.Status.Any(e => e.StatusId == id);
        }
    }
}

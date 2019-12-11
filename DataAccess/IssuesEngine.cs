﻿using DataAccess.Interfaces;
using DataAccess.Models;

using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class IssuesEngine : IIssuesEngine
    {
        private readonly DataContext _context;
        public IssuesEngine(DataContext context)
        {
            _context = context;
        }

        public async Task<int> CreateIssue(Issue issue)
        {
            _context.Issues.Add(issue);
            await _context.SaveChangesAsync();

            return issue.IssueId;
        }

        public bool EditIssue(int id, Issue issue)
        {
             _context.Issues.Update(issue);
            _context.SaveChangesAsync();
            return true;
        }

        public Issue GetIssue(int id)
        {
            return _context.Issues.FirstOrDefault(i => i.IssueId == id);
        }

        public bool RemoveIssue(Issue issue)
        {
            _context.Issues.Remove(issue);
            _context.SaveChangesAsync();
            return true;
        }

        public bool IssueExists(int id)
        {
            return _context.Issues.Any(e => e.IssueId == id);
        }
    }
}

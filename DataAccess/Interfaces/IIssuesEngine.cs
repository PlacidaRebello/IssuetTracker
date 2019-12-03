﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace DataAccess.Interfaces
{
    public interface IIssuesEngine
    {
        Task<int> CreateIssue(Issue issue);
        Issue GetIssue(int id);
        void RemoveIssue(Issue issue);
        void EditIssue(int id, Issue issue);

        bool IssueExists(int id);
    }
}
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Interfaces
{
    public interface IIssuesLogic
    {
        Task<int> CreateIssue(Issue issue);
        void RemoveIssue(int id);
        Issue GetIssue(int id);
        void EditIssue(int id,Issue issue);
    }
}

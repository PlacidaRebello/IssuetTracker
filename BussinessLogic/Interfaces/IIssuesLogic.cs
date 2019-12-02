using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Interfaces
{
    public interface IIssuesLogic
    {
        Task<int> CreateIssue(DataAccess.Models.Issue issue);
    }
}

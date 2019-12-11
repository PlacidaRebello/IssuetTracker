using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace DataAccess.Interfaces
{
    public interface IIssuesEngine
    {
        int CreateIssue(Issue issue);
        Issue GetIssue(int id);
        bool RemoveIssue(Issue issue);
        bool EditIssue(Issue issue);

        bool IssueExists(int id);
    }
}

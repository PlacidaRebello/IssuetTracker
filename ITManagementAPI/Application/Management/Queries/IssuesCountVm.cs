using AutoMapper;
using DataAccess.Models;
using ITManagementAPI.Application.Automapper;

namespace ITManagementAPI.Application.Management.Queries
{
    public class IssuesCountVm: IMapFrom<IssuesCountByType>
    {
        public string TypeName { get; set; }
        public int IssueCount { get; set; }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using ITManagementAPI.Application.Management.Queries;
using MicroservicesTemplate.Common.Controller;
using Microsoft.AspNetCore.Mvc;
using ITManagementAPI.Application.Management.Commands;

namespace ITManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ApiController
    {
        [HttpGet]
        [Route("InitialIssuesList")]
        public async Task<List<IssuesVm>> GetInitialIssueList()
        {
            return await Mediator.Send(new GetIssuesListQuery());
        }

        [HttpPut]
        [Route("UpdateIssuePriority")]
        public async Task<bool> UpdateIssuePriority(UpdateIssuePriorityCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet]
        [Route("GetIssuesCountByType")]
        public async Task<List<IssuesCountVm>> GetIssueCountByType()
        {
            return await Mediator.Send(new GetIssuesCountByTypeQuery());
        }
        [HttpGet]
        [Route("GetBurnDownData")]
        public async Task<List<DailyBurnDownVm>> GetDailyBurnDowns()
        {
            return await Mediator.Send(new GetDailyBurnDownsQuery());
        }
    }
}
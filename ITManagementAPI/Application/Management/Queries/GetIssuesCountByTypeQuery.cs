using AutoMapper;
using DataAccess.Models;
using ITManagementAPI.Infrastructure.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ITManagementAPI.Application.Management.Queries
{
    public class GetIssuesCountByTypeQuery : IRequest<List<IssuesCountVm>>
    {
    }
    public class GetIssuesCountByTypeQueryHandler : IRequestHandler<GetIssuesCountByTypeQuery, List<IssuesCountVm>>
    {
        private readonly IMapper _mapper;
        private readonly IDashboardService _dashboardService;
        public GetIssuesCountByTypeQueryHandler(IMapper mapper, IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
            _mapper = mapper;
        }
        public async Task<List<IssuesCountVm>> Handle(GetIssuesCountByTypeQuery request, CancellationToken cancellationToken)
        {
            var response =  _dashboardService.GetIssuesCountByType();
            if (response.Count < 3)
            {
                IssuesCountByType objIssues ;
                if (response.Any(x => x.TypeName != "Bug")) 
                {
                    objIssues = new IssuesCountByType();
                    objIssues.IssueCount = 0;
                    objIssues.TypeName = "Bug";
                    response.Add(objIssues);
                }
                if (response.Any(x => x.TypeName != "Story"))
                {
                    objIssues = new IssuesCountByType();
                    objIssues.IssueCount = 0;
                    objIssues.TypeName = "Story";
                    response.Add(objIssues);
                }
                if (response.Any(x => x.TypeName != "Task"))
                {
                    objIssues = new IssuesCountByType();
                    objIssues.IssueCount = 0;
                    objIssues.TypeName = "Task";
                    response.Add(objIssues);
                }
            }
            var viewModel = _mapper.Map<List<IssuesCountVm>>(response);

            return await Task.FromResult(viewModel);
        }
    }
}       

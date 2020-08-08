using AutoMapper;
using ITManagementAPI.Infrastructure.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ITManagementAPI.Application.Management.Queries
{
    public class GetIssuesListQuery : IRequest<List<IssuesVm>>
    {
    }
    public class GetIssuesListQueryHandler : IRequestHandler<GetIssuesListQuery, List<IssuesVm>>
    {
        private readonly IMapper _mapper;
        private readonly IDashboardService _dashboardService;
        public GetIssuesListQueryHandler(IMapper mapper, IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
            _mapper = mapper;
        }
        public async Task<List<IssuesVm>> Handle(GetIssuesListQuery request, CancellationToken cancellationToken)
        {
            var response = await _dashboardService.GetManagementIssuesList();
            var viewModel = _mapper.Map<List<IssuesVm>>(response);

            return await Task.FromResult(viewModel);
        }
    }
}
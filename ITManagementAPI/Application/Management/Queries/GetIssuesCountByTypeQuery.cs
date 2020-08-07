using AutoMapper;
using ITManagementAPI.Infrastructure.Persistence;
using MediatR;
using System.Collections.Generic;
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
            var viewModel = _mapper.Map<List<IssuesCountVm>>(response);

            return await Task.FromResult(viewModel);
        }
                
    }
}       

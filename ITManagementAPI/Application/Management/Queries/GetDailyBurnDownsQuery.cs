using AutoMapper;
using ITManagementAPI.Infrastructure.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ITManagementAPI.Application.Management.Queries
{
    public class GetDailyBurnDownsQuery : IRequest<List<DailyBurnDownVm>>
    {
    }
    public class GetDailyBurnDownsQueryHandler : IRequestHandler<GetDailyBurnDownsQuery, List<DailyBurnDownVm>>
    {
        private readonly IMapper _mapper;
        private readonly IDashboardService _dashboardService;
        public GetDailyBurnDownsQueryHandler(IMapper mapper, IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
            _mapper = mapper;
        }
        public async Task<List<DailyBurnDownVm>> Handle(GetDailyBurnDownsQuery request, CancellationToken cancellationToken)
        {
            var response = await _dashboardService.GetDataForBurnDownChart();
            var viewModel = _mapper.Map<List<DailyBurnDownVm>>(response);
           
            return await Task.FromResult(viewModel);
        }

        
    }
}

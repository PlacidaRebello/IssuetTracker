using AutoMapper;
using DataAccess.Models;
using ITManagementAPI.Application.Automapper;
using ITManagementAPI.Infrastructure.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ITManagementAPI.Application.Management.Commands
{
    public class UpdateIssuePriorityCommand : IRequest<bool>, IMapFrom<IssuePriority>
    {
        public bool PrevItem { get; set; }
        public int PrevItemId { get; set; }
        public int NextItemId { get; set; }
        public int CurrentItemIndex { get; set; }
        public int IssueStatus { get; set; }
        public int IssueId { get; set; }
       
    }
    public class UpdateIssuePriorityCommandHandler : IRequestHandler<UpdateIssuePriorityCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IDashboardService _dashboardService;
        public UpdateIssuePriorityCommandHandler(IMapper mapper, IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
            _mapper = mapper;
        }
        public async Task<bool> Handle(UpdateIssuePriorityCommand request, CancellationToken cancellationToken)
        {
            var issue = _dashboardService.GetIssuePriorityById(request.IssueId);
            var issues = _dashboardService.GetIssueListByPriority();

            var item = issues.Find(x => x.IssueId == issue.IssueId);
            if (item != null)
                issues.Remove(item);

            IssuePriority prevIssue, NextIssue;
            if (request.CurrentItemIndex >= decimal.Divide(issues.Count, 2))
            {
                if (request.PrevItem)
                {
                    prevIssue = _dashboardService.GetIssuePriorityById(request.PrevItemId);
                    issue.IssueOrder = prevIssue.IssueOrder + 1;
                }
                else
                {
                    NextIssue = _dashboardService.GetIssuePriorityById(request.NextItemId);
                    issue.IssueOrder = NextIssue.IssueOrder - 1;
                }
                // issue belongs to 2nd half
                for (int i = request.CurrentItemIndex; i < issues.Count; i++)
                {
                    if (issues[i].IssueOrder <= issue.IssueOrder)
                    {
                        issues[i].IssueOrder = issue.IssueOrder + 1;
                    }
                    else if (i > 0 && issues[i].IssueOrder <= issues[i - 1].IssueOrder)
                    {
                        issues[i].IssueOrder = issues[i - 1].IssueOrder + 1;
                    }
                }
            }
            else
            {
                if (request.PrevItem)
                {
                    prevIssue = _dashboardService.GetIssuePriorityById(request.PrevItemId);
                    issue.IssueOrder = prevIssue.IssueOrder;
                }
                else
                {
                    NextIssue = _dashboardService.GetIssuePriorityById(request.NextItemId);
                    issue.IssueOrder = NextIssue.IssueOrder - 1;
                }
                //isue belongs to 1st half
                for (int i = request.CurrentItemIndex - 1; i >= 0; i--)
                {
                    if (issues[i].IssueOrder >= issue.IssueOrder)
                    {
                        issues[i].IssueOrder = issue.IssueOrder - 1;
                        int j = i;
                    }
                    if (issues[i].IssueOrder >= issues[i + 1].IssueOrder)
                    {
                        issues[i].IssueOrder = issues[i + 1].IssueOrder - 1;
                    }
                }
            }

            issues.Add(issue);
            return await _dashboardService.UpdateIssuePriorities(issues);
        }
    }
}

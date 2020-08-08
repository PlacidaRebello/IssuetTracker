using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITManagementAPI.Infrastructure.Persistence
{
    public class DashboardService : IDashboardService
    {
        private readonly DataContext _context;
        public DashboardService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<DailyBurnDown>> GetDataForBurnDownChart()
        {
            var d = (from dailyBurnDown in _context.DailyBurnDown
                     join sprints in _context.Sprints
                     on dailyBurnDown.SprintId equals sprints.SprintId
                     where DateTime.Now >= sprints.StartDate && DateTime.Now <= sprints.EndDate
                     orderby dailyBurnDown.Date ascending
                     select new DailyBurnDown
                     {
                         SprintId = sprints.SprintId,
                         Date = dailyBurnDown.Date,
                         PointsCompleted = dailyBurnDown.PointsCompleted,
                         PointsPending = dailyBurnDown.PointsPending
                     }).ToListAsync();
            return await d;
        }

        public List<IssuePriority> GetIssueListByPriority()
        {
            var issueList = (from Issue in _context.Issues
                             join Sprints in _context.Sprints
                             on Issue.SprintId equals Sprints.SprintId
                             join IssuePriority in _context.IssuePriority
                             on Issue.IssueId equals IssuePriority.IssueId
                             where DateTime.Now >= Sprints.StartDate && DateTime.Now <= Sprints.EndDate
                             orderby IssuePriority.IssueOrder ascending
                             select new IssuePriority
                             {
                                 IssueId = Issue.IssueId,
                                 IssueOrder = IssuePriority.IssueOrder,
                                 IssuePriorityId = IssuePriority.IssuePriorityId
                             }).ToList();
            return  issueList;
        }

        public IssuePriority GetIssuePriorityById(int id)
        {
            return _context.IssuePriority.FirstOrDefault(s => s.IssueId == id);
        }

        public List<IssuesCountByType> GetIssuesCountByType()
        {
            var issues = (from Issue in _context.Issues
                      join Sprints in _context.Sprints
                      on Issue.SprintId equals Sprints.SprintId
                      join IssueType in _context.IssueType
                      on Issue.IssueTypeId equals IssueType.IssueTypeId
                      where DateTime.Now >= Sprints.StartDate && DateTime.Now <= Sprints.EndDate
                      select new Issue
                      {
                          IssueId = Issue.IssueId,
                          IssueTypeName = IssueType.IssueTypeName
                      }).ToList();

            var issueCount = (from issue in issues
                              group issue by issue.IssueTypeName into IssueGp
                              select new IssuesCountByType
                              {
                                  TypeName = IssueGp.Key,
                                  IssueCount = IssueGp.Count()
                              }).ToList();
            return issueCount;
        }

        public async Task<List<Issue>> GetManagementIssuesList()
        {
            var issueList = (from Issue in _context.Issues
                             join Sprints in _context.Sprints
                             on Issue.SprintId equals Sprints.SprintId
                             join IssuePriority in _context.IssuePriority
                             on Issue.IssueId equals IssuePriority.IssueId
                             where DateTime.Now >= Sprints.StartDate && DateTime.Now <= Sprints.EndDate
                             orderby IssuePriority.IssueOrder ascending
                             select new Issue
                             {
                                 IssueId = Issue.IssueId,
                                 Subject = Issue.Subject,
                                 Description = Issue.Description,
                                 UserId = Issue.UserId,
                                 Tags = Issue.Tags,
                                 IssueStatusId = Issue.IssueStatusId,
                                 Order = IssuePriority.IssueOrder,
                                 IssueTypeId = Issue.IssueTypeId,
                                 IssueDetails = Issue.IssueDetails,
                                 SprintId = Issue.SprintId
                             }).ToListAsync();
            return await issueList;
        }

        public async Task<bool> UpdateIssuePriorities(IEnumerable<IssuePriority> issues)
        {
            _context.IssuePriority.UpdateRange(issues);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

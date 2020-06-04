using ServiceModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Interfaces;

namespace DataAccess
{
    public class IssuePriorityEngine : IIssuePriorityEngine
    {
        private readonly DataContext _context;
        public IssuePriorityEngine(DataContext context)
        {
            _context = context;
        }
        public List<Issue> GetManagementIssuesList()
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
                             }).ToList();
            return issueList;
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
            return issueList;
        }

        public IssuePriority GetIssuePriorityById(int id)
        {
            return _context.IssuePriority.FirstOrDefault(s => s.IssueId == id);
        }

        public bool UpdateIssuePriorities(List<IssuePriority> issues)
        {
            _context.IssuePriority.UpdateRange(issues);
            _context.SaveChanges();
            return true;
        }
        public List<IssuesCountByType> GetIssuesByType()
        {
            List<Issue> issues = new List<Issue>();
            issues = (from Issue in _context.Issues
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

            return (from issue in issues
                    group issue by issue.IssueTypeName into IssueGp
                    select new IssuesCountByType
                    {
                        TypeName = IssueGp.Key,
                        IssueCount = IssueGp.Count()
                    }).ToList();

        }

        public List<DailyBurnDown> GetDataForBurnDownChart()
        {
            var d = (from DailyBurnDown in _context.DailyBurnDown
                     join Sprints in _context.Sprints
                     on DailyBurnDown.SprintId equals Sprints.SprintId
                     where DateTime.Now >= Sprints.StartDate && DateTime.Now <= Sprints.EndDate
                     orderby DailyBurnDown.Date ascending
                     select new DailyBurnDown
                     {
                         SprintId = Sprints.SprintId,
                         Date = DailyBurnDown.Date,
                         PointsCompleted = DailyBurnDown.PointsCompleted,
                         PointsPending = DailyBurnDown.PointsPending
                     }).ToList();
            return d;
        }
    }

}

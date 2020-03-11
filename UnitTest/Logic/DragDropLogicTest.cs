using BussinessLogic.Logic;
using DataAccess.Interfaces;
using DataAccess.Models;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTest.Logic
{
    public class DragDropLogicTest
    {
        readonly Mock<IIssuesEngine> mockIssuesEngine;
        public DragDropLogicTest()
        {
            mockIssuesEngine = new Mock<IIssuesEngine>();
        }

        [Theory]
        [InlineData(false,0,1,0,3,1)]
        [InlineData(true,1,6,1,2,1)]
        [InlineData(true,1,0,2,2,1)]
        [InlineData(false,0,3,0,6,2)]
        [InlineData(true,3,5,1,2,2)]
        [InlineData(true,4,0,2,3,3)]
        public void DropItem_ListReordered_Successfull(bool previtem, int prevItemId, int nextItemId, int currentItemIndex,int issueId,int issueStatusId)
        {
            Issue issue = CreateSampleIssue(issueId);
            List<Issue> issues=CreateSampleData(issueStatusId);
            Issue prevIssue = CreateSampleIssue(prevItemId);
            Issue nextIssue = CreateSampleIssue(nextItemId); 
            mockIssuesEngine.Setup(x => x.GetIssue(prevItemId)).Returns(prevIssue);
            mockIssuesEngine.Setup(x => x.GetIssue(nextItemId)).Returns(nextIssue);

            if (currentItemIndex >= decimal.Divide(issues.Count, 2))
            {
                if (previtem)
                {
                    issue.Order = prevIssue.Order + 1;
                }
                else
                {
                    issue.Order = nextIssue.Order - 1;
                }
                // issue belongs to 2nd half
                for (int i = currentItemIndex; i < issues.Count; i++)
                {
                    if (issues[i].Order <= issue.Order)
                    {
                        issues[i].Order = issue.Order + 1;
                    }
                    else if (i > 0 && issues[i].Order <= issues[i - 1].Order)
                    {
                        issues[i].Order = issues[i - 1].Order + 1;
                    }
                }
            }
            else
            {
                if (previtem)
                {
                    issue.Order = prevIssue.Order;
                }
                else
                {
                    issue.Order = nextIssue.Order - 1;
                }
                //isue belongs to 1st half
                for (int i = currentItemIndex - 1; i >= 0; i--)
                {
                    if (issues[i].Order >= issue.Order)
                    {
                        issues[i].Order = issue.Order - 1;
                        int j = i;
                    }
                    if (issues[i].Order >= issues[i + 1].Order)
                    {
                        issues[i].Order = issues[i + 1].Order - 1;
                    }
                }
            }
            issues.Add(issue);
            DragDropLogic dragDropLogic = new DragDropLogic(mockIssuesEngine.Object);
            List<Issue> expected = issues;
            List<Issue> actual = dragDropLogic.DropItem(previtem, prevItemId, nextItemId, currentItemIndex,CreateSampleIssue(issueId),CreateSampleData(issueStatusId));
           
            actual.Should().BeEquivalentTo(expected);
        }


        public List<Issue> CreateSampleData(int IssueStatusId=1)
        {
            var issue1 = CreateSampleIssue();
            var issue2 = CreateSampleIssue(2, 3);
            var issue3 = CreateSampleIssue(3, 2);
            var issue4 = CreateSampleIssue(4, 3);
            var issue5 = CreateSampleIssue(5, 2);
            var issue6 = CreateSampleIssue(6, 1);
            List<Issue> issues=new List<Issue>();
            if (IssueStatusId == 1)
            {
                issues.Add(issue1);
                issues.Add(issue6);
            }
            else if (IssueStatusId == 2)
            {
                issues.Add(issue3);
                issues.Add(issue5);
            }
            else
            {
                issues.Add(issue2);
                issues.Add(issue4);
            }
            return issues;
        }
        private Issue CreateSampleIssue(int issueId = 1, int issueStatusId = 1)
        {
            Issue issue = new Issue()
            {
                IssueId = issueId,
                Subject = "abc",
                Description = "do it",
                AssignedTo = "placi",
                Tags = "to be done",
                IssueStatusId = issueStatusId,
                CreatedBy = "jason",
                Order = issueId
            };
            return issue;
        }
    }
}

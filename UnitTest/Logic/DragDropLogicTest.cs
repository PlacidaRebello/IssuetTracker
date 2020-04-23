using BussinessLogic.Logic;
using DataAccess.Interfaces;
using DataAccess.Models;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
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
        [InlineData(true,7,0,3,3,3)]
        public void DropItemInCompletedAtIndex3_ListReordered_Successfull(bool previtem, int prevItemId, int nextItemId, int currentItemIndex,int issueId,int issueStatusId)
        {
            Issue issue = CreateSampleIssue(issueId);
            List<Issue> issues=CreateSampleData(issueStatusId);
            Issue prevIssue = CreateSampleIssue(prevItemId);
            Issue nextIssue = CreateSampleIssue(nextItemId); 
            mockIssuesEngine.Setup(x => x.GetIssue(prevItemId)).Returns(prevIssue);
            mockIssuesEngine.Setup(x => x.GetIssue(nextItemId)).Returns(nextIssue);
            issue.Order = 8;
            issues.Add(issue);
            List<Issue> expected = issues;

            DragDropLogic dragDropLogic = new DragDropLogic(mockIssuesEngine.Object);           
            List<Issue> actual = dragDropLogic.DropItem(previtem, prevItemId, nextItemId, currentItemIndex,CreateSampleIssue(issueId),CreateSampleData(issueStatusId));
           
            actual.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData(false, 0, 3, 0, 6, 2)]
        public void DropItemInProgressAtIndex0_ListReordered_Successfull(bool previtem, int prevItemId, int nextItemId, int currentItemIndex, int issueId, int issueStatusId)
        {
            Issue issue = CreateSampleIssue(issueId);
            List<Issue> issues = CreateSampleData(issueStatusId);
            Issue prevIssue = CreateSampleIssue(prevItemId);
            Issue nextIssue = CreateSampleIssue(nextItemId);
            mockIssuesEngine.Setup(x => x.GetIssue(prevItemId)).Returns(prevIssue);
            mockIssuesEngine.Setup(x => x.GetIssue(nextItemId)).Returns(nextIssue);
            issue.Order = 2;
            issues.Add(issue);
            List<Issue> expected = issues;
            
            DragDropLogic dragDropLogic = new DragDropLogic(mockIssuesEngine.Object);
            List<Issue> actual = dragDropLogic.DropItem(previtem, prevItemId, nextItemId, currentItemIndex, CreateSampleIssue(issueId), CreateSampleData(issueStatusId));
            actual.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData(true, 3, 5, 1, 2, 2)]
        public void DropItemInProgressAtIndex1_ListReordered_Successfull(bool previtem, int prevItemId, int nextItemId, int currentItemIndex, int issueId, int issueStatusId)
        {
            Issue issue = CreateSampleIssue(issueId);
            List<Issue> issues = CreateSampleData(issueStatusId);
            Issue prevIssue = CreateSampleIssue(prevItemId);
            Issue nextIssue = CreateSampleIssue(nextItemId);
            mockIssuesEngine.Setup(x => x.GetIssue(prevItemId)).Returns(prevIssue);
            mockIssuesEngine.Setup(x => x.GetIssue(nextItemId)).Returns(nextIssue);
            issue.Order = 4;
            issues.Add(issue);
            List<Issue> expected = issues;

            DragDropLogic dragDropLogic = new DragDropLogic(mockIssuesEngine.Object);
            List<Issue> actual = dragDropLogic.DropItem(previtem, prevItemId, nextItemId, currentItemIndex, CreateSampleIssue(issueId), CreateSampleData(issueStatusId));
            actual.Should().BeEquivalentTo(expected);
        }
        [Theory]
        [InlineData(true, 5, 0, 2, 2, 2)]
        public void DropItemInProgressAtIndex2_ListReordered_Successfull(bool previtem, int prevItemId, int nextItemId, int currentItemIndex, int issueId, int issueStatusId)
        {
            Issue issue = CreateSampleIssue(issueId);
            List<Issue> issues = CreateSampleData(issueStatusId);
            Issue prevIssue = CreateSampleIssue(prevItemId);
            Issue nextIssue = CreateSampleIssue(nextItemId);
            mockIssuesEngine.Setup(x => x.GetIssue(prevItemId)).Returns(prevIssue);
            mockIssuesEngine.Setup(x => x.GetIssue(nextItemId)).Returns(nextIssue);
            issue.Order = 6;
            issues.Add(issue);
            List<Issue> expected = issues;

            DragDropLogic dragDropLogic = new DragDropLogic(mockIssuesEngine.Object);
            List<Issue> actual = dragDropLogic.DropItem(previtem, prevItemId, nextItemId, currentItemIndex, CreateSampleIssue(issueId), CreateSampleData(issueStatusId));
            actual.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData(true, 1, 6, 1, 2, 1)]
        public void DropItemInToDoAtIndex1_ListReordered_Successfull(bool previtem, int prevItemId, int nextItemId, int currentItemIndex, int issueId, int issueStatusId)
        {
            Issue issue = CreateSampleIssue(issueId);
            List<Issue> issues = CreateSampleData(issueStatusId);
            Issue prevIssue = CreateSampleIssue(prevItemId);
            Issue nextIssue = CreateSampleIssue(nextItemId);
            mockIssuesEngine.Setup(x => x.GetIssue(prevItemId)).Returns(prevIssue);
            mockIssuesEngine.Setup(x => x.GetIssue(nextItemId)).Returns(nextIssue);
            issue.Order = 2;
            issues.Add(issue);
            List<Issue> expected = issues;

            DragDropLogic dragDropLogic = new DragDropLogic(mockIssuesEngine.Object);
            List<Issue> actual = dragDropLogic.DropItem(previtem, prevItemId, nextItemId, currentItemIndex, CreateSampleIssue(issueId), CreateSampleData(issueStatusId));
            actual.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData(false, 0, 1, 0, 3, 1)]
        public void DropItemInToDoAtIndex0_ListReordered_Successfull(bool previtem, int prevItemId, int nextItemId, int currentItemIndex, int issueId, int issueStatusId)
        {
            Issue issue = CreateSampleIssue(issueId);
            List<Issue> issues = CreateSampleData(issueStatusId);
            Issue prevIssue = CreateSampleIssue(prevItemId);
            Issue nextIssue = CreateSampleIssue(nextItemId);
            mockIssuesEngine.Setup(x => x.GetIssue(prevItemId)).Returns(prevIssue);
            mockIssuesEngine.Setup(x => x.GetIssue(nextItemId)).Returns(nextIssue);
            issue.Order = 0;
            issues.Add(issue);
            List<Issue> expected = issues;

            DragDropLogic dragDropLogic = new DragDropLogic(mockIssuesEngine.Object);
            List<Issue> actual = dragDropLogic.DropItem(previtem, prevItemId, nextItemId, currentItemIndex, CreateSampleIssue(issueId), CreateSampleData(issueStatusId));
            actual.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData(true,2,4,1,7,3)]
        public void DropItemToSameList_ReOrderList_Successful(bool previtem, int prevItemId, int nextItemId, int currentItemIndex, int issueId, int issueStatusId)
        {
            Issue issue = CreateSampleIssue(issueId, issueStatusId);
            List<Issue> issues = CreateSampleData(issueStatusId);
            Issue prevIssue = CreateSampleIssue(prevItemId);
            Issue nextIssue = CreateSampleIssue(nextItemId);
            mockIssuesEngine.Setup(x => x.GetIssue(prevItemId)).Returns(prevIssue);
            mockIssuesEngine.Setup(x => x.GetIssue(nextItemId)).Returns(nextIssue);
            issues.RemoveAll(x=>x.IssueId==issue.IssueId);
            issue.Order = 3;
            issues.Add(issue);
            List<Issue> expected = issues;

            DragDropLogic dragDropLogic = new DragDropLogic(mockIssuesEngine.Object);
            List<Issue> actual = dragDropLogic.DropItem(previtem, prevItemId, nextItemId, currentItemIndex, CreateSampleIssue(issueId,issueStatusId), CreateSampleData(issueStatusId));
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
            var issue7 = CreateSampleIssue(7, 3);
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
                issues.Add(issue7);
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
                UserId = "placi",
                Tags = "to be done",
                IssueStatusId = issueStatusId,
                CreatedBy = "jason",
                Order = issueId
            };
            return issue;
        }

    }
}

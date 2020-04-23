using BussinessLogic;
using BussinessLogic.Factory;
using BussinessLogic.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Models;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTest.Logic
{
    public class IssueLogicTest
    {
        readonly Mock<IIssuesEngine> mockIssuesEngine;
        readonly Mock<IDragDropLogic> mockDragDropLogic;
        public IssueLogicTest()
        {
            mockIssuesEngine = new Mock<IIssuesEngine>();
            mockDragDropLogic = new Mock<IDragDropLogic>();
        }

        [Fact]
        public void GetIssues_ReturnsSuccessfull()
        {
            var issue1 = CreateSampleIssue();
            var issue2 = CreateSampleIssue(2,2);
            var issue3 = CreateSampleIssue(3,3);
            List<Issue> Issueobj = new List<Issue>();
            Issueobj.Add(issue1);
            Issueobj.Add(issue2);
            Issueobj.Add(issue3);

            mockIssuesEngine.Setup(x => x.GetIssueList())
               .Returns(Issueobj);

            var expected = Issueobj;

            IssuesLogic issuesLogic = new IssuesLogic(mockIssuesEngine.Object, mockDragDropLogic.Object);

            var actual = issuesLogic.GetIssueList();

            Assert.Equal(expected, actual);
            actual.Should().BeEquivalentTo(expected);
        }
        [Fact]
        public void GetIssueById_ValidData()
        {
            mockIssuesEngine.Setup(x => x.GetIssue(1))
               .Returns(CreateSampleIssue());

            var expected = CreateSampleIssue();

            IssuesLogic issuesLogic = new IssuesLogic(mockIssuesEngine.Object, mockDragDropLogic.Object);

            var actual = issuesLogic.GetIssue(1);

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void CreateIssue_IssueExists_IssueOrderSetToMax_NewIssueCreatedSuccessfully()
        {
            //Issue issue = new Issue()
            //{
            //    // IssueId = 1,
            //    Subject = "abc",
            //    Description = "do it",
            //    AssignedTo = "placi",
            //    Tags = "to be done",
            //    IssueStatusId=1,
            //    CreatedBy = "jason"
            //};
            Issue issue = GetSampleIssue();

            mockIssuesEngine.Setup(x => x.IssueExists())
                .Returns(true);
            mockIssuesEngine.Setup(x => x.GetMaxOrder())
                .Returns(1);
            issue.Order = 2;
            
            mockIssuesEngine.Setup(x => x.CreateIssue(issue))
                .Returns(2);

            IssuesLogic issuesLogic = new IssuesLogic(mockIssuesEngine.Object,mockDragDropLogic.Object);
            int expected = 2;
            var actual = issuesLogic.CreateIssue(issue);

            Assert.Equal(expected, actual);
            mockIssuesEngine.Verify(x => x.CreateIssue(issue), Times.Once);
        }

        [Fact]
        public void CreateIssue_IssueDoesNotExists_SetIssueOrderToOne_NewIssueCreatedSuccessfully()
        {            
            Issue issue = GetSampleIssue();
            mockIssuesEngine.Setup(x => x.IssueExists())
                .Returns(false);
            issue.Order = 1;
            mockIssuesEngine.Setup(x => x.CreateIssue(issue))
                .Returns(1);           

            IssuesLogic issuesLogic = new IssuesLogic(mockIssuesEngine.Object, mockDragDropLogic.Object);
            int expected = 1;
            int actual = issuesLogic.CreateIssue(issue);

            Assert.Equal(expected, actual);
            mockIssuesEngine.Verify(x => x.CreateIssue(issue), Times.Once);
        }

        [Fact]
        public void EditIssue_IssueDoesNotExists_ThrowsException()
        {
            var issue = CreateSampleIssue();
            mockIssuesEngine.Setup(x => x.EditIssue(issue))
                .Returns(true);

            mockIssuesEngine.Setup(x => x.IssueExists(issue.IssueId))
                .Returns(false);

            IssuesLogic issuesLogic = new IssuesLogic(mockIssuesEngine.Object,mockDragDropLogic.Object);

            Action act = () => { issuesLogic.EditIssue(issue); };

            act.Should().Throw<Exception>()
                .And.Message
                .Should().Be("Issue does not exists");

            mockIssuesEngine.Verify(x => x.EditIssue(issue), Times.Never);
        }

        [Fact]
        public void EditIssue_IssueEdited_ValidCall()
        {
            var issue = CreateSampleIssue();
            mockIssuesEngine.Setup(x => x.EditIssue(issue))
                .Returns(true);

            mockIssuesEngine.Setup(x => x.IssueExists(issue.IssueId))
                .Returns(true);

            bool expected = true;

            IssuesLogic issuesLogic = new IssuesLogic(mockIssuesEngine.Object, mockDragDropLogic.Object);

            bool actual = issuesLogic.EditIssue(issue);

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void DeleteIssue_IssueDoesNotExists_ThrowsException()
        {
            var issue = CreateSampleIssue();
            mockIssuesEngine.Setup(x => x.RemoveIssue(issue))
                .Returns(true);

            mockIssuesEngine.Setup(x => x.GetIssue(issue.IssueId))
                .Returns((Issue)null);

            IssuesLogic issuesLogic = new IssuesLogic(mockIssuesEngine.Object, mockDragDropLogic.Object);

            Action act = () => { issuesLogic.RemoveIssue(issue.IssueId); };

            act.Should().Throw<Exception>()
                .And.Message
                .Should().Be("Issue does not exists");

            mockIssuesEngine.Verify(x => x.RemoveIssue(issue), Times.Never);
        }

        [Fact]
        public void DeleteIssue_IssueDeleted_ValidCall()
        {
            var issue = CreateSampleIssue();
            mockIssuesEngine.Setup(x => x.RemoveIssue(issue))
                .Returns(true);

            mockIssuesEngine.Setup(x => x.GetIssue(issue.IssueId))
                .Returns(issue);

            IssuesLogic issuesLogic = new IssuesLogic(mockIssuesEngine.Object, mockDragDropLogic.Object);

            bool expected = true;
            bool actual = issuesLogic.RemoveIssue(issue.IssueId);

            Assert.Equal(expected, actual);

            mockIssuesEngine.Verify(x => x.RemoveIssue(issue), Times.Once);
        }
        
        [Fact]
        public void DragDropIssue_IssueListUpdated_ValidCall() 
        {
            var issue1 = CreateSampleIssue();
            var issue2 = CreateSampleIssue(2,1);
            var issue3 = CreateSampleIssue(3,2);
            var issue4 = CreateSampleIssue(4,3);

            List<Issue> issueInProgress = new List<Issue>();
            issueInProgress.Add(issue3);

            List<Issue> reOrderedIssues = new List<Issue>();
            issue4.Order = 2;
            reOrderedIssues.Add(issue3);
            reOrderedIssues.Add(issue4);

            mockIssuesEngine.Setup(x => x.GetIssue(4)).Returns(issue4);
            issue4.IssueStatusId = 2;

            mockIssuesEngine.Setup(x => x.GetIssueListByStatus(2)).Returns(issueInProgress);

            mockDragDropLogic.Setup(x => x.DropItem(false, 0, 3, 0, issue4, issueInProgress))
                .Returns(reOrderedIssues);

            mockIssuesEngine.Setup(x=>x.DragDropIssueList(reOrderedIssues)).Returns(true);

            IssuesLogic issuesLogic = new IssuesLogic(mockIssuesEngine.Object, mockDragDropLogic.Object);

            bool expected = true;
            bool actual = issuesLogic.DragDropIssues(false,0,3,0,2,4);
            Assert.Equal(expected, actual);
            mockIssuesEngine.Verify(x => x.DragDropIssueList(reOrderedIssues), Times.Once);
        }
        private Issue GetSampleIssue()
        {
            Issue issue = new Issue()
            {
                //IssueId = 1,
                Subject = "abc",
                Description = "do it",
                UserId = "placi",
                Tags = "to be done",
                IssueStatusId=1,
                CreatedBy = "jason",
                IssueTypeId=3,
                Order=0,
                SprintId=1,
                IssueDetails= new IssueDetails{ 
                    AcceptanceCriteria="abcd",
                    Attachment="defghijklmno",
                    UserId="abcd21234asd",
                    Enviroment="c#",
                    Browser="Chrome",
                    StoryPoints=2,
                    Epic=1,
                    UAT=false,
                    TimeTracking="none"
                }
            };
            return issue;
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
                StatusName = "TODO",
                Order = issueId,
                SprintId = 1,
                IssueTypeId=3
            };
            return issue;
        }
    }
}
﻿using BussinessLogic;
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
        public void GetIssueById_ValidData()
        {
            mockIssuesEngine.Setup(x => x.GetIssue(1))
               .Returns(GetSampleIssue());

            var expected = GetSampleIssue();

            IssuesLogic issuesLogic = new IssuesLogic(mockIssuesEngine.Object, mockDragDropLogic.Object);

            var actual = issuesLogic.GetIssue(1);

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void SaveIssue_ValidCall()
        {
            //IssueStatus objStatus = new IssueStatus()
            //{
            //    IssueStatusId = 1,
            //    StatusName = "nt done",
            //    CreatedBy = ""
            //};
            Issue issue = new Issue()
            {
                // IssueId = 1,
                Subject = "abc",
                Description = "do it",
                AssignedTo = "placi",
                Tags = "to be done",
                IssueStatusId=1,
                CreatedBy = "jason"
            };

            mockIssuesEngine.Setup(x => x.CreateIssue(issue))
                .Returns(1);

            //mockStatusLogic.Setup(x => x.GetStatusByName("nt done"))
            //.Returns(objStatus);

            IssuesLogic issuesLogic = new IssuesLogic(mockIssuesEngine.Object,mockDragDropLogic.Object);
            int expected = 1;
            var actual = issuesLogic.CreateIssue(issue);

            Assert.Equal(expected, actual);
            mockIssuesEngine.Verify(x => x.CreateIssue(issue), Times.Once);
        }

        //[Fact]
        //public void CreateIssue_Null_Status_Throws_ExceptionAsync()
        //{
        //    mockIssuesEngine.Setup(x => x.CreateIssue(GetSampleIssue()))
        //        .Returns(1);

        //    mockStatusLogic.Setup(x => x.GetStatusByName("nt done"))
        //        .Returns((IssueStatus)null);

        //    IssuesLogic issuesLogic = new IssuesLogic(mockIssuesEngine.Object, mockStatusLogic.Object);

        //    Action act = () => { issuesLogic.CreateIssue(GetSampleIssue()); };

        //    act.Should().Throw<Exception>()
        //     .And.Message
        //     .Should().Be("Status doesn't exist. Please create a status and then add Issues");

        //    mockIssuesEngine.Verify(x => x.CreateIssue(GetSampleIssue()), Times.Never);

        //}

        [Fact]
        public void EditIssue_IssueDoesNotExists_ThrowsException()
        {
            var issue = GetSampleIssue();
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
            var issue = GetSampleIssue();
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
            var issue = GetSampleIssue();
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
            var issue = GetSampleIssue();
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
            //List<Issue> issueObj = new List<Issue>();            
            //issueObj.Add(issue1);
            //issueObj.Add(issue2);
            //issueObj.Add(issue3);
            //issueObj.Add(issue4);

            List<Issue> issueInProgress = new List<Issue>();
            issueInProgress.Add(issue3);

            List<Issue> reOrderedIssues = new List<Issue>();
            issue4.Order = 2;
            reOrderedIssues.Add(issue3);
            reOrderedIssues.Add(issue4);

            mockIssuesEngine.Setup(x => x.GetIssue(4))
                .Returns(issue4);
            issue4.IssueStatusId = 2;
            mockIssuesEngine.Setup(x => x.GetIssueListByStatus(2))
                .Returns(issueInProgress);
            mockDragDropLogic.Setup(x => x.DropItem(false, 0, 3, 0, issue4, issueInProgress)).Returns(reOrderedIssues);
            mockIssuesEngine.Setup(x=>x.DragDropIssueList(reOrderedIssues))
                .Returns(true);
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
                IssueId = 1,
                Subject = "abc",
                Description = "do it",
                AssignedTo = "placi",
                Tags = "to be done",
                IssueStatusId=1,
                CreatedBy = "jason"
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
                AssignedTo = "placi",
                Tags = "to be done",
                IssueStatusId = issueStatusId,
                CreatedBy = "jason",
                Order=issueId
            };
            return issue;
        }
    }
}
﻿using BussinessLogic;
using DataAccess.Interfaces;
using DataAccess.Models;
using FluentAssertions;
using Moq;
using System;
using Xunit;

namespace UnitTest.Logic
{
    public class StatusLogicTest
    {
        readonly Mock<IIssueStatusEngine> mockStatusEngine;

        public StatusLogicTest()
        {
            mockStatusEngine = new Mock<IIssueStatusEngine>();
        }

        [Fact]
        public void CreateStatus_ValidCall()
        {
            IssueStatus status = new IssueStatus()
            {
                StatusName = "In progress",
                CreatedBy = "Placida"
            };

            mockStatusEngine.Setup(x => x.CreateStatus(status))
                .Returns(1);

            IssueStatusLogic statusLogic = new IssueStatusLogic(mockStatusEngine.Object);

            int expected = 1;
            int actual = statusLogic.CreateStatus(status);

            Assert.Equal(expected, actual);
            mockStatusEngine.Verify(x => x.CreateStatus(status), Times.Once);
        }

        [Fact]
        public void EditStatus_EditedSuccessfull_ValidCall()
        {
            var status = CreateSampleStatus();

            mockStatusEngine.Setup(x => x.EditStatus(status))
                .Returns(true);

            mockStatusEngine.Setup(x => x.StatusExists(status.IssueStatusId))
               .Returns(true);

            IssueStatusLogic statusLogic = new IssueStatusLogic(mockStatusEngine.Object);

            bool expected = true;
            bool actual = statusLogic.EditStatus(status);

            Assert.Equal(expected, actual);
            mockStatusEngine.Verify(x => x.EditStatus(status), Times.Once);
        }

        [Fact]
        public void EditStatus_StatusDoesNotExists_throwsException()
        {
            var status = CreateSampleStatus();

            mockStatusEngine.Setup(x => x.EditStatus(status))
                .Returns(true);

            mockStatusEngine.Setup(x => x.StatusExists(status.IssueStatusId))
                .Returns(false);

            IssueStatusLogic statusLogic = new IssueStatusLogic(mockStatusEngine.Object);

            Action act = () => { statusLogic.EditStatus(status); };

            act.Should().Throw<Exception>()
             .And.Message
             .Should().Be("Status Doesnot exists ");

            mockStatusEngine.Verify(x => x.EditStatus(status), Times.Never);
        }

        [Fact]
        public void GetStatusById_ReturnsSuccessfull()
        {
            var status = CreateSampleStatus();
            mockStatusEngine.Setup(x => x.GetStatus(1))
               .Returns(status);

            var expected = CreateSampleStatus();

            IssueStatusLogic statusLogic = new IssueStatusLogic(mockStatusEngine.Object);

            var actual = statusLogic.GetStatus(1);

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void DeleteStatus_StatusDoesNotExists_ThrowsException()
        {
            var status = CreateSampleStatus();
            mockStatusEngine.Setup(x => x.RemoveStatus(status))
                .Returns(true);

            mockStatusEngine.Setup(x => x.GetStatus(1))
                .Returns((IssueStatus)null);

            IssueStatusLogic statusLogic = new IssueStatusLogic(mockStatusEngine.Object);
            Action act = () => { statusLogic.RemoveStatus(status.IssueStatusId); };

            act.Should().Throw<Exception>()
                .And.Message
                .Should().Be("Status doesnot exists");

            mockStatusEngine.Verify(x => x.RemoveStatus(status), Times.Never);
        }

        [Fact]
        public void DeleteStatus_StatusDeleted_ReturnsSuccessfull()
        {
            var status = CreateSampleStatus();
            mockStatusEngine.Setup(x => x.RemoveStatus(status))
                           .Returns(true);

            mockStatusEngine.Setup(x => x.GetStatus(status.IssueStatusId))
                .Returns(status);

            IssueStatusLogic statusLogic = new IssueStatusLogic(mockStatusEngine.Object);

            bool expected = true;
            bool actual = statusLogic.RemoveStatus(status.IssueStatusId);

            Assert.Equal(expected, actual);

            mockStatusEngine.Verify(x => x.RemoveStatus(status), Times.Once);
        }

        [Fact]
        public void GetStatusByName_ReturnsSuccessful()
        {
            var status = CreateSampleStatus();

            mockStatusEngine.Setup(x => x.GetStatusByName("In progress"))
                .Returns(status);

            IssueStatusLogic statusLogic = new IssueStatusLogic(mockStatusEngine.Object);

            var expected = status;
            var actual = statusLogic.GetStatusByName("In progress");

            Assert.Equal(expected, actual);
            actual.Should().BeEquivalentTo(expected);
        }

        private IssueStatus CreateSampleStatus()
        {
            IssueStatus status = new IssueStatus()
            {
                IssueStatusId = 1,
                StatusName = "In progress",
                CreatedBy = "Placida"
            };
            return status;
        }
    }
}

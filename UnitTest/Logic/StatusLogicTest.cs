using BussinessLogic;
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
        readonly Mock<IStatusEngine> mockStatusEngine;

        public StatusLogicTest()
        {
            mockStatusEngine = new Mock<IStatusEngine>();
        }

        [Fact]
        public void CreateStatus_ValidCall()
        {
            Status status = new Status()
            {
                StatusName = "In progress",
                CreatedBy = "Placida"
            };


            mockStatusEngine.Setup(x => x.CreateStatus(status))
                .Returns(1);

            StatusLogic statusLogic = new StatusLogic(mockStatusEngine.Object);

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

            mockStatusEngine.Setup(x => x.StatusExists(status.StatusId))
               .Returns(true);

            StatusLogic statusLogic = new StatusLogic(mockStatusEngine.Object);

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

            mockStatusEngine.Setup(x => x.StatusExists(status.StatusId))
                .Returns(false);

            StatusLogic statusLogic = new StatusLogic(mockStatusEngine.Object);

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

            StatusLogic statusLogic = new StatusLogic(mockStatusEngine.Object);

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
                .Returns((Status)null);

            StatusLogic statusLogic = new StatusLogic(mockStatusEngine.Object);
            Action act = () => { statusLogic.RemoveStatus(status.StatusId); };

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

            mockStatusEngine.Setup(x => x.GetStatus(status.StatusId))
                .Returns(status);

            StatusLogic statusLogic = new StatusLogic(mockStatusEngine.Object);

            bool expected = true;
            bool actual = statusLogic.RemoveStatus(status.StatusId);

            Assert.Equal(expected, actual);

            mockStatusEngine.Verify(x => x.RemoveStatus(status), Times.Once);
        }


        [Fact]
        public void GetStatusByName_ReturnsSuccessful()
        {
            var status = CreateSampleStatus();


            mockStatusEngine.Setup(x => x.GetStatusByName("In progress"))
                .Returns(status);

            StatusLogic statusLogic = new StatusLogic(mockStatusEngine.Object);

            var expected = status;
            var actual = statusLogic.GetStatusByName("In progress");

            Assert.Equal(expected, actual);

            actual.Should().BeEquivalentTo(expected);
            //mockStatusEngine.Verify(x => x.GetStatusByName(status), Times.Once);
        }

        private Status CreateSampleStatus()
        {
            Status status = new Status()
            {
                StatusId = 1,
                StatusName = "In progress",
                CreatedBy = "Placida"
            };

            return status;
        }
    }
}

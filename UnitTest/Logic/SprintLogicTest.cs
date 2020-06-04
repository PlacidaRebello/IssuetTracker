using BussinessLogic;
using DataAccess.Interfaces;
using ServiceModel.Models;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTest.Logic
{
    public class SprintLogicTest
    {
        readonly Mock<ISprintEngine> mockSprintEngine;
        public SprintLogicTest()
        {
            mockSprintEngine = new Mock<ISprintEngine>();
        }

        [Fact]
        public void CreateSprint_SprintCreatedSuccessfully_ReturnsSprintId()
        {
            Sprint sprint = new Sprint()
            {
                SprintName = "test1",
                SprintPoints = 2.0m,
                StartDate = new DateTime(2019, 6, 1),
                EndDate = new DateTime(2019, 12, 1),
                SprintStatusId = 1,
                CreatedBy = "user",
                CreatedDate = DateTime.Now
            };

            mockSprintEngine.Setup(x => x.CreateSprint(sprint))
                .Returns(1);

            SprintLogic sprintLogic = new SprintLogic(mockSprintEngine.Object);

            int expected = 1;
            int actual = sprintLogic.CreateSprint(sprint);

            Assert.Equal(expected, actual);
            mockSprintEngine.Verify(x => x.CreateSprint(sprint), Times.Once);
        }

        [Fact]
        public void EditSprint_EditedSuccessfull_returnsSprint()
        {
            var sprint = CreateSampleSprint();

            mockSprintEngine.Setup(x => x.EditSprint(sprint))
                .Returns(true);

            mockSprintEngine.Setup(x => x.SprintExists(sprint.SprintId))
               .Returns(true);

            SprintLogic sprintLogic = new SprintLogic(mockSprintEngine.Object);

            bool expected = true;
            bool actual = sprintLogic.EditSprint(sprint);

            Assert.Equal(expected, actual);
            mockSprintEngine.Verify(x => x.EditSprint(sprint), Times.Once);
        }

        [Fact]
        public void EditSprint_SprintDoesNotExists_ThrowsException()
        {
            var sprint = CreateSampleSprint();

            mockSprintEngine.Setup(x => x.EditSprint(sprint))
                .Returns(true);

            mockSprintEngine.Setup(x => x.SprintExists(sprint.SprintId))
               .Returns(false);

            SprintLogic sprintLogic = new SprintLogic(mockSprintEngine.Object);

            Action act = () => { sprintLogic.EditSprint(sprint); };
            act.Should().Throw<Exception>()
                .And.Message
                .Should().Be("Sprint does not exists");

            mockSprintEngine.Verify(x => x.EditSprint(sprint), Times.Never);
        }

        [Fact]
        public void GetSprintById_ReturnsSuccessfull()
        {
            var sprint = CreateSampleSprint();
            mockSprintEngine.Setup(x => x.GetSprint(1))
               .Returns(sprint);

            var expected = CreateSampleSprint();

            SprintLogic SprintLogic = new SprintLogic(mockSprintEngine.Object);

            var actual = SprintLogic.GetSprint(1);

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void DeleteSprint_SprintDoesNotExists_ThrowsException()
        {
            var sprint = CreateSampleSprint();
            mockSprintEngine.Setup(x => x.RemoveSprint(sprint))
                .Returns(true);

            mockSprintEngine.Setup(x => x.GetSprint(1))
                .Returns((Sprint)null);

            SprintLogic SprintLogic = new SprintLogic(mockSprintEngine.Object);
            Action act = () => { SprintLogic.RemoveSprint(sprint.SprintId); };

            act.Should().Throw<Exception>()
                .And.Message
                .Should().Be("Sprint does not exists");

            mockSprintEngine.Verify(x => x.RemoveSprint(sprint), Times.Never);
        }

        [Fact]
        public void DeleteSprint_SprintDeleted_ReturnsSuccessfull()
        {
            var sprint = CreateSampleSprint();
            mockSprintEngine.Setup(x => x.RemoveSprint(sprint))
                           .Returns(true);

            mockSprintEngine.Setup(x => x.GetSprint(sprint.SprintId))
                .Returns(sprint);

            SprintLogic SprintLogic = new SprintLogic(mockSprintEngine.Object);

            bool expected = true;
            bool actual = SprintLogic.RemoveSprint(sprint.SprintId);

            Assert.Equal(expected, actual);

            mockSprintEngine.Verify(x => x.RemoveSprint(sprint), Times.Once);
        }

        [Fact]
        public void GetSprints_ReturnsSuccessfull()
        {
            var sprint1 = CreateSampleSprint();
            var sprint2 = CreateSampleSprint(2);
            List<Sprint> sprintobj = new List<Sprint>();
            sprintobj.Add(sprint1);
            sprintobj.Add(sprint2);

            mockSprintEngine.Setup(x => x.GetSprints())
               .Returns(sprintobj);

            var expected = sprintobj;

            SprintLogic SprintLogic = new SprintLogic(mockSprintEngine.Object);

            var actual = SprintLogic.GetSprints();

            Assert.Equal(expected, actual);
            actual.Should().BeEquivalentTo(expected);
        }

        private Sprint CreateSampleSprint(int sprintId = 1)
        {
            Sprint sprint = new Sprint()
            {
                SprintId = sprintId,
                SprintName = "test1",
                SprintPoints = 2.0m,
                StartDate = new DateTime(2019, 6, 1),
                EndDate = new DateTime(2019, 12, 1),
                SprintStatusId = 1,
                CreatedBy = "user",
                CreatedDate = new DateTime(2019, 12, 30)
            };
            return sprint;
        }
    }
}

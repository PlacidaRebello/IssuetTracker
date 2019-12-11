using BussinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using DataAccess.Interfaces;
using Xunit;
using DataAccess.Models;
using BussinessLogic;
using FluentAssertions;

namespace XUnitTestProject.Logic
{
    public class IssueTypeLogicTest
    {
        Mock<IIssueTypeEngine> mockIssueTypeEngine;

        public IssueTypeLogicTest()
        {
            mockIssueTypeEngine = new Mock<IIssueTypeEngine>();
        }

        [Fact]
        public void CreateIssueType_ReturnsSuccessful()
        {
            IssueType issueType = new IssueType()
            {
                IssueTypeName = "WebApi",
                CreatedBy = "Placida"                
            };


            mockIssueTypeEngine.Setup(x => x.CreateIssueType(issueType))
                .Returns(1);

            IssueTypeLogic issueTypeLogic = new IssueTypeLogic(mockIssueTypeEngine.Object);

            int expected = 1;
            int actual = issueTypeLogic.CreateIssueType(issueType);

            Assert.Equal(expected, actual);
            mockIssueTypeEngine.Verify(x => x.CreateIssueType(issueType), Times.Once);

        }

        [Fact]
        public void GetIssueTypeById_ReturnsSuccessfull()
        {
            var issueType = CreateSampleIssueType();
           
            mockIssueTypeEngine.Setup(x => x.GetIssueType(1))
               .Returns(issueType);

            var expected = CreateSampleIssueType();

            IssueTypeLogic issueTypeLogic = new IssueTypeLogic(mockIssueTypeEngine.Object);

            var actual = issueTypeLogic.GetIssueType(1);

            actual.Should().BeEquivalentTo(expected);
        }


        [Fact]
        public void EditIssueType_EditedSuccessfull_ValidCall()
        {
            var issueType = CreateSampleIssueType();

            mockIssueTypeEngine.Setup(x => x.EditIssueType(issueType))
                .Returns(true);

            mockIssueTypeEngine.Setup(x => x.IssueTypeExists(issueType.IssueTypeId))
               .Returns(true);

            IssueTypeLogic issueTypeLogic = new IssueTypeLogic(mockIssueTypeEngine.Object);

            bool expected = true;
            bool actual = issueTypeLogic.EditIssueType(issueType);

            Assert.Equal(expected, actual);
            mockIssueTypeEngine.Verify(x => x.EditIssueType(issueType), Times.Once);
        }

        [Fact]
        public void EditIssueType_IssueTypeDoesNotExists_throwsException()
        {
            var issueType = CreateSampleIssueType();

            mockIssueTypeEngine.Setup(x => x.EditIssueType(issueType))
                .Returns(true);

            mockIssueTypeEngine.Setup(x => x.IssueTypeExists(issueType.IssueTypeId))
               .Returns(false);

            IssueTypeLogic issueTypeLogic = new IssueTypeLogic(mockIssueTypeEngine.Object);


            Action act = () => { issueTypeLogic.EditIssueType(issueType); };

            act.Should().Throw<Exception>()
             .And.Message
             .Should().Be("IssueType Does not exists");

            mockIssueTypeEngine.Verify(x => x.EditIssueType(issueType), Times.Never);
        }

        [Fact]
        public void DeleteStatus_StatusDoesNotExists_ThrowsException()
        {
            var issueType = CreateSampleIssueType();

            mockIssueTypeEngine.Setup(x => x.RemoveIssueType(issueType))
                .Returns(true);

            mockIssueTypeEngine.Setup(x => x.GetIssueType(issueType.IssueTypeId))
               .Returns((IssueType)null);

            IssueTypeLogic issueTypeLogic = new IssueTypeLogic(mockIssueTypeEngine.Object);


            Action act = () => { issueTypeLogic.RemoveIssueType(1); };

            act.Should().Throw<Exception>()
             .And.Message
             .Should().Be("IssueType Does not exists");

            mockIssueTypeEngine.Verify(x => x.RemoveIssueType(issueType), Times.Never);
        }

        [Fact]
        public void DeleteStatus_StatusDeleted_ReturnsSuccessfull()
        {
            var issueType = CreateSampleIssueType();

            mockIssueTypeEngine.Setup(x => x.RemoveIssueType(issueType))
                .Returns(true);

            mockIssueTypeEngine.Setup(x => x.GetIssueType(1))
               .Returns(issueType);

            IssueTypeLogic issueTypeLogic = new IssueTypeLogic(mockIssueTypeEngine.Object);

            bool expected = true;
            bool actual = issueTypeLogic.RemoveIssueType(1);

            Assert.Equal(expected, actual);
            mockIssueTypeEngine.Verify(x => x.RemoveIssueType(issueType), Times.Once);

        }


        private IssueType CreateSampleIssueType()
        {
            IssueType issueType = new IssueType()
            {
                IssueTypeId = 1,
                IssueTypeName = "WebApi",
                CreatedBy = "Placida"
            };

            return issueType;
        }

    }
}

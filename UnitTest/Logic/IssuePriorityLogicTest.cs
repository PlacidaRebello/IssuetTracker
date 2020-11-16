using System;
using System.Collections.Generic;
using System.Text;
using BussinessLogic;
using DataAccess.Interfaces;
using Moq;
using Xunit;

namespace UnitTest.Logic
{
    public class IssuePriorityLogicTest
    {
        private readonly Mock<IIssuePriorityEngine> mockIssuePriorityEngine;
        
        public IssuePriorityLogicTest()
        { 
            mockIssuePriorityEngine = new Mock<IIssuePriorityEngine>();
        }

        [Fact]
        public void GetDailyBurnDowns_Returns_ListOfDailyBurnDownData()
        {
            //Arrange
            mockIssuePriorityEngine.Setup(x => x.GetDataForBurnDownChart());

            //Act
            IssuePriorityLogic issuesPriorityLogic = new IssuePriorityLogic(mockIssuePriorityEngine.Object);
            issuesPriorityLogic.GetDailyBurnDowns();

            //Assert
            mockIssuePriorityEngine.Verify(x => x.GetDataForBurnDownChart(), Times.Once);
        }

        [Fact]
        public void GetIssuesCountByTypes_Returns_CountOfIssuesByType()
        {
            //Arrange
            mockIssuePriorityEngine.Setup(x => x.GetIssuesByType());

            //Act
            IssuePriorityLogic issuesPriorityLogic = new IssuePriorityLogic(mockIssuePriorityEngine.Object);
            issuesPriorityLogic.GetIssuesCountByTypes();

            //Assert
            mockIssuePriorityEngine.Verify(x => x.GetIssuesByType(), Times.Once);
        }
        [Fact]
        public void GetManagementIssuesList_Returns_ListOfIssues()
        {
            //Arrange
            mockIssuePriorityEngine.Setup(x => x.GetManagementIssuesList());

            //Act
            IssuePriorityLogic issuesPriorityLogic = new IssuePriorityLogic(mockIssuePriorityEngine.Object);
            issuesPriorityLogic.GetManagementIssuesList();

            //Assert
            mockIssuePriorityEngine.Verify(x => x.GetManagementIssuesList(), Times.Once);
        }
    }
}

using System.Collections.Generic;
using BussinessLogic;
using DataAccess.Interfaces;
using DataAccess.Models;
using FluentAssertions;
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

        [Fact]
        public void UpdateIssuePriority_IssueDroppedInSecondHalf_Returns_NewIssueOrderList()
        {
            //Arrange
            var issue1 = CreateSampleIssuePriority();
            var issue2 = CreateSampleIssuePriority(2, 2);
            var issue3 = CreateSampleIssuePriority(3, 3);
            var issue4 = CreateSampleIssuePriority(4, 4);

            var issuePriorityList=new List<IssuePriority>();
            issuePriorityList.Add(issue1);
            issuePriorityList.Add(issue2);
            issuePriorityList.Add(issue3);
            issuePriorityList.Add(issue4);

            mockIssuePriorityEngine.Setup(x => x.GetIssuePriorityById(3)).Returns(issue3);
            mockIssuePriorityEngine.Setup(x => x.GetIssuePriorityById(2)).Returns(issue2);
            mockIssuePriorityEngine.Setup(x => x.GetIssuePriorityById(1)).Returns(issue1);
            mockIssuePriorityEngine.Setup(x => x.GetIssueListByPriority()).Returns(issuePriorityList);
            mockIssuePriorityEngine.Setup(x=>x.UpdateIssuePriorities(It.IsAny<List<IssuePriority>>()));

            //Act
            var issuesPriorityLogic = new IssuePriorityLogic(mockIssuePriorityEngine.Object);
            var newIssuePriorityList = issuesPriorityLogic.UpdateIssuePrirority(true,3,4,2,1);

            //Assert
            mockIssuePriorityEngine.Verify(x => x.GetIssuePriorityById(1), Times.Once);
            mockIssuePriorityEngine.Verify(x => x.GetIssuePriorityById(3), Times.Once);
            newIssuePriorityList[3].IssueOrder.Should().Be(4);
            newIssuePriorityList[2].IssueOrder.Should().Be(5);
        }
      
        [Fact]
        public void UpdateIssuePriority_IssueDroppedInFirstHalf()
        {
            //Arrange
            var issue1 = CreateSampleIssuePriority();
            var issue2 = CreateSampleIssuePriority(2, 2);
            var issue3 = CreateSampleIssuePriority(3, 3);
            var issue4 = CreateSampleIssuePriority(4, 4);

            var issuePriorityList = new List<IssuePriority>();
            issuePriorityList.Add(issue1);
            issuePriorityList.Add(issue2);
            issuePriorityList.Add(issue3);
            issuePriorityList.Add(issue4);

            mockIssuePriorityEngine.Setup(x => x.GetIssuePriorityById(3)).Returns(issue3);
            mockIssuePriorityEngine.Setup(x => x.GetIssuePriorityById(2)).Returns(issue2);
            mockIssuePriorityEngine.Setup(x => x.GetIssuePriorityById(1)).Returns(issue1);
            mockIssuePriorityEngine.Setup(x => x.GetIssueListByPriority()).Returns(issuePriorityList);

            //Act
            var issuesPriorityLogic = new IssuePriorityLogic(mockIssuePriorityEngine.Object);
            var newIssuePriorityList = issuesPriorityLogic.UpdateIssuePrirority(true, 1, 2, 1, 3);

            //Assert
            mockIssuePriorityEngine.Verify(x => x.GetIssuePriorityById(1), Times.Once);
            mockIssuePriorityEngine.Verify(x => x.GetIssuePriorityById(2), Times.Never);
            newIssuePriorityList[0].IssueOrder.Should().Be(0);
            newIssuePriorityList[3].IssueOrder.Should().Be(1);
        }

        [Fact]
        public void UpdateIssuePriority_IssueDroppedAtTopOfList()
        {
            //Arrange
            var issue1 = CreateSampleIssuePriority();
            var issue2 = CreateSampleIssuePriority(2, 2);
            var issue3 = CreateSampleIssuePriority(3, 3);
            var issue4 = CreateSampleIssuePriority(4, 4);

            var issuePriorityList = new List<IssuePriority>();
            issuePriorityList.Add(issue1);
            issuePriorityList.Add(issue2);
            issuePriorityList.Add(issue3);
            issuePriorityList.Add(issue4);

            mockIssuePriorityEngine.Setup(x => x.GetIssuePriorityById(3)).Returns(issue3);
            mockIssuePriorityEngine.Setup(x => x.GetIssuePriorityById(2)).Returns(issue2);
            mockIssuePriorityEngine.Setup(x => x.GetIssuePriorityById(1)).Returns(issue1);
            mockIssuePriorityEngine.Setup(x => x.GetIssueListByPriority()).Returns(issuePriorityList);

            //Act
            var issuesPriorityLogic = new IssuePriorityLogic(mockIssuePriorityEngine.Object);
            var newIssuePriorityList = issuesPriorityLogic.UpdateIssuePrirority(false, 0, 1, 0, 3);

            //Assert
            mockIssuePriorityEngine.Verify(x => x.GetIssuePriorityById(1), Times.Once);
            newIssuePriorityList[3].IssueOrder.Should().Be(0);
        }

        [Fact]
        public void UpdateIssuePriority_IssueDroppedAtBottomOfList()
        {
            //Arrange
            var issue1 = CreateSampleIssuePriority();
            var issue2 = CreateSampleIssuePriority(2, 2);
            var issue3 = CreateSampleIssuePriority(3, 3);
            var issue4 = CreateSampleIssuePriority(4, 4);

            var issuePriorityList = new List<IssuePriority>();
            issuePriorityList.Add(issue1);
            issuePriorityList.Add(issue2);
            issuePriorityList.Add(issue3);
            issuePriorityList.Add(issue4);

            mockIssuePriorityEngine.Setup(x => x.GetIssuePriorityById(4)).Returns(issue4);
            mockIssuePriorityEngine.Setup(x => x.GetIssuePriorityById(2)).Returns(issue2);
            mockIssuePriorityEngine.Setup(x => x.GetIssuePriorityById(1)).Returns(issue1);
            mockIssuePriorityEngine.Setup(x => x.GetIssueListByPriority()).Returns(issuePriorityList);

            //Act
            var issuesPriorityLogic = new IssuePriorityLogic(mockIssuePriorityEngine.Object);
            var newIssuePriorityList = issuesPriorityLogic.UpdateIssuePrirority(true, 4, 0, 4, 2);

            //Assert
            mockIssuePriorityEngine.Verify(x => x.GetIssuePriorityById(4), Times.Once);
            newIssuePriorityList[3].IssueOrder.Should().Be(5);
        }

        [Fact]
        public void UpdateIssuePriority_IssueDroppedInMiddleOfList()
        {
            //Arrange
            var issue1 = CreateSampleIssuePriority();
            var issue2 = CreateSampleIssuePriority(2, 2);
            var issue3 = CreateSampleIssuePriority(3, 3);
            var issue4 = CreateSampleIssuePriority(4, 4);

            var issuePriorityList = new List<IssuePriority>();
            issuePriorityList.Add(issue1);
            issuePriorityList.Add(issue2);
            issuePriorityList.Add(issue3);
            issuePriorityList.Add(issue4);

            mockIssuePriorityEngine.Setup(x => x.GetIssuePriorityById(3)).Returns(issue3);
            mockIssuePriorityEngine.Setup(x => x.GetIssuePriorityById(2)).Returns(issue2);
            mockIssuePriorityEngine.Setup(x => x.GetIssuePriorityById(4)).Returns(issue4);
            mockIssuePriorityEngine.Setup(x => x.GetIssuePriorityById(1)).Returns(issue1);
            mockIssuePriorityEngine.Setup(x => x.GetIssueListByPriority()).Returns(issuePriorityList);

            //Act
            var issuesPriorityLogic = new IssuePriorityLogic(mockIssuePriorityEngine.Object);
            var newIssuePriorityList = issuesPriorityLogic.UpdateIssuePrirority(true, 2, 3, 2, 4);

            //Assert
            mockIssuePriorityEngine.Verify(x => x.GetIssuePriorityById(4), Times.Once);
            newIssuePriorityList[3].IssueOrder.Should().Be(3);
            newIssuePriorityList[2].IssueOrder.Should().Be(4);
        }

        private IssuePriority CreateSampleIssuePriority(int issueId = 1, int issueOrder = 1)
        {
            var issue = new Issue
            {
                IssueId = issueId,
                Subject = "abc",
                Description = "do it",
                UserId = "placi",
                Tags = "to be done",
                IssueStatusId = 1,
                CreatedBy = "jason",
                StatusName = "TODO",
                Order = issueId,
                SprintId = 1,
                IssueTypeId = 3
            };

            var issuePriority = new IssuePriority
            {
                IssuePriorityId = issueId, IssueOrder = issueOrder, IssueId = issueId, Issue = issue
            };
            return issuePriority;
        }
    }
}

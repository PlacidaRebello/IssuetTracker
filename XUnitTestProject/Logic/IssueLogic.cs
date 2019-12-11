using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ServiceModel.Dto;
using Autofac.Extras.Moq;
using Moq;
using BussinessLogic.Interfaces;
using DataAccess.Models;
using DataAccess.Interfaces;
using BussinessLogic;
using FluentAssertions;
using System.Threading.Tasks;

namespace XUnitTestProject.Logic
{
    public class IssueLogic
    {
        readonly Mock<IIssuesEngine> mockIssuesEngine;
        readonly Mock<IStatusLogic> mockStatusLogic;
        public IssueLogic()
        {
            mockIssuesEngine = new Mock<IIssuesEngine>();
            mockStatusLogic = new Mock<IStatusLogic>();
        }
        
        //Unit test methods should be like this "MethodBeingTested_TestCase_ExpectedOutcome"
        [Fact]
        public void GetIssueById_ValidData()
        {
            mockIssuesEngine.Setup(x => x.GetIssue(1))
               .Returns(GetSampleIssue());

            var expected = GetSampleIssue();

            IssuesLogic issuesLogic = new IssuesLogic(mockIssuesEngine.Object, mockStatusLogic.Object);

            var actual = issuesLogic.GetIssue(1);

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void SaveIssue_ValidCall()
        {
            Status objStatus = new Status()
            {
                StatusId=1,
                StatusName="nt done",
                CreatedBy=""
            };

            mockIssuesEngine.Setup(x => x.GetIssue(1))
               .Returns(GetSampleIssue());

            mockStatusLogic.Setup(x => x.GetStatusByName("nt done"))
            .ReturnsAsync(objStatus);

            var expected = GetSampleIssue().IssueId;

            IssuesLogic issuesLogic = new IssuesLogic(mockIssuesEngine.Object, mockStatusLogic.Object);

            var actual = issuesLogic.CreateIssue(GetSampleIssue());

            Assert.True(actual!=null);
            Assert.Equal(expected,actual.Id);

        }

        [Fact]
        public void CreateIssue_Null_Status_Throws_ExceptionAsync()        
        {

            mockIssuesEngine.Setup(x => x.GetIssue(1))
               .Returns(GetSampleIssue());
            mockStatusLogic.Setup(x => x.GetStatusByName("nt done"))
                .ReturnsAsync((Status)null);

            var expected = GetSampleIssue().IssueId;

            IssuesLogic issuesLogic = new IssuesLogic(mockIssuesEngine.Object, mockStatusLogic.Object);

            Func<Task> act = async () => { await issuesLogic.CreateIssue(GetSampleIssue()); };

            act.Should().Throw<Exception>()
             .And.Message
             .Should().Be("Status doesn't exist. Please create a status and then add Issues");

            mockIssuesEngine.Verify(x => x.CreateIssue(GetSampleIssue()), Times.Never);

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
                Status = new Status
                {
                    StatusId = 1,
                    StatusName = "nt done",
                    CreatedBy = ""
                },
                CreatedBy = "jason"
            };
            return issue;
        }      
    }
}

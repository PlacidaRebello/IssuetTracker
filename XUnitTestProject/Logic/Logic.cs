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
    public class Logic
    {

        //[Fact]
        //public void GetIssueById_validData()
        //{
        //    using (var mock = AutoMock.GetLoose())
        //    {
        //        mock.Mock<IIssuesLogic>()
        //            .Setup(x => x.GetIssue(1))
        //            .Returns(GetSampleIssue());

        //        var cls = mock.Create<IssuesController>();

        //        var expected = GetSampleIssue();


        //        var actual = cls.GetIssue(1);

        //        Assert.True(actual != null);

        //        Assert.Equal(expected.AssignedTo,actual.AssignedTo);
        //    }
        //}

        [Fact]
        public void GetIssueById_ValidData() 
        {
            var mock = new Mock<IIssuesEngine>();
                mock.Setup(x => x.GetIssue(1))
                   .Returns(GetSampleIssue());

            var mock2 = new Mock<IStatusLogic>();           

            var expected = GetSampleIssue();                
            
            IssuesLogic issuesLogic = new IssuesLogic(mock.Object, mock2.Object);

            var actual = issuesLogic.GetIssue(1);

            //expected.Status.StatusName = "asfasdf";

            actual.Should().BeEquivalentTo(expected);

            //Assert.True(actual!=null);
            //Assert.Equal(expected.Subject,actual.Subject);
            //Assert.Equal(expected.Status.GetType(), actual.Status.GetType());
            //Assert.Equal(expected.AssignedTo, actual.AssignedTo); 
            //Assert.Equal(expected.Description, actual.Description);
            //Assert.Equal(expected.Tags, actual.Tags);
        }

        //Unit test methods should be like this "MethodBeingTested_TestCase_ExpectedOutcome"
        [Fact]
        public void SaveIssue_ValidCall()
        {
            Status objStatus = new Status()
            {
                StatusId=1,
                StatusName="nt done",
                CreatedBy=""
            };

            var mock = new Mock<IIssuesEngine>();
            mock.Setup(x => x.GetIssue(1))
               .Returns(GetSampleIssue());

            var mock2 =  new Mock<IStatusLogic>();
            mock2.Setup(x => x.GetStatusByName("nt done"))
            .ReturnsAsync(objStatus);

            var expected = GetSampleIssue().IssueId;

            IssuesLogic issuesLogic = new IssuesLogic(mock.Object, mock2.Object);

            var actual = issuesLogic.CreateIssue(GetSampleIssue());

            Assert.True(actual!=null);
            Assert.Equal(expected,actual.Id);

        }

        [Fact]
        public void SaveIssue_Null_Status_Throws_ExceptionAsync()        {

            var mock = new Mock<IIssuesEngine>();
            mock.Setup(x => x.GetIssue(1))
               .Returns(GetSampleIssue());

            var mock2 = new Mock<IStatusLogic>();
            mock2.Setup(x => x.GetStatusByName("nt done"))
                .ReturnsAsync((Status)null);

            var expected = GetSampleIssue().IssueId;

            IssuesLogic issuesLogic = new IssuesLogic(mock.Object, mock2.Object);


            Func<Task> act = async () => { await issuesLogic.CreateIssue(GetSampleIssue()); };

            act.Should().Throw<Exception>()
             .And.Message
             .Should().Be("Status doesn't exist. Please create a status and then add Issues");

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

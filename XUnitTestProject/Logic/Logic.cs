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
            using (var mock= AutoMock.GetLoose())
            {
                mock.Mock<IIssuesEngine>()
                   .Setup(x => x.GetIssue(1))
                   .Returns(GetSampleIssue());

                var expected = GetSampleIssue();
                
            //    var actual= 
            }
        }


        //[Fact]
        //public void SaveIssue_ValidCall() 
        //{
        //    using (var mock= AutoMock.GetLoose())
        //    {
               
        //        var issue = new Issue()
        //        {
        //            IssueId = 1,
        //            Subject = "abc",
        //            Description = "do it",
        //            AssignedTo = "placi",
        //            Tags = "to be done",
        //            Status = new Status
        //            {
        //                StatusId = 1,
        //                StatusName = "nt done",
        //                CreatedBy = ""
        //            },
        //            CreatedBy = "jason"
        //        };              
                    
                    
        //    }
        //}

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

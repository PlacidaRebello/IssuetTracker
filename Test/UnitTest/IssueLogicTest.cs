using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using BussinessLogic;
using DataAccess;
using DataAccess.Interfaces;
using DataAccess.Models;
using Moq;
using System.Threading.Tasks;
using BussinessLogic.Interfaces;

namespace Test.UnitTest
{
    public class IssueLogicTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreateIssueStatusDoesNotExistsThrowsException()
        {
            //setup
            var statusLogicMock = new Mock<IStatusLogic>();
            statusLogicMock.Setup(s => s.GetStatusByName(It.IsAny<string>()))
            .Returns((Task<Status>)null);

            var issuesEngineMock = new Mock<IIssuesEngine>();            
            IssuesLogic il = new IssuesLogic(issuesEngineMock.Object, statusLogicMock.Object);
           
            var status = new Status();
            status.StatusName = "Test";

            var issue = new Issue();
            issue.Status = status;
            //act

            var val = il.CreateIssue(issue);
            //assert         

        }
        //public async Task<int> CreateIssue(Issue issue)
        //{
        //    var status = await _statusEngine.GetStatusByName(issue.Status.StatusName);

        //    if (status == null)
        //    {
        //        throw new Exception("Status doesn't exist. Please create a status and then add Issues");
        //    }

        //    issue.Status = status;
        //    return await _issuesEngine.CreateIssue(issue);
        //}

    }
}

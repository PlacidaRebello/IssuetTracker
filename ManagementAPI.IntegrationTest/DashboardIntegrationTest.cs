﻿using System.Collections.Generic;
using System.Net.Http;
using ITManagementAPI;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using Xunit;
using ITManagementAPI.Application.Management.Queries;
using FluentAssertions;
using System.Net;
using ITManagementAPI.Application.Management.Commands;

namespace ManagementAPI.IntegrationTest
{
    public class DashboardIntegrationTest
    {
        public readonly HttpClient _client;
        public DashboardIntegrationTest()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            _client = appFactory.CreateClient();
        }

        [Fact]
        public async Task GetInitialIssueList_WithoutParameters_ReturnsAllIssuesForManagement()
        {
            //Act
            var response = await _client.GetAsync("api/Dashboard/InitialIssuesList");
            var IssuesList = await response.Content.ReadAsAsync<List<IssuesVm>>();

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            IssuesList.Should().NotBeEmpty();
        }
        [Fact]
        public async Task GetIssuesCountByType_ReturnsAllCorrectIssuesCountWithType()
        {
            //Act
            var response = await _client.GetAsync("api/Dashboard/GetIssuesCountByType");
            var IssuesList = await response.Content.ReadAsAsync<List<IssuesCountVm>>();

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);            
            IssuesList.Should().NotBeNull();
        }
       
        [Fact]
        public async Task GetDailyBurnDowns_ReturnsCorrectBurnDownData()
        {
            //Arrange
            //DailyBurnDown objBurnDown = new DailyBurnDown();
            //objBurnDown.SprintId = 5;
            //objBurnDown.Date = DateTime.Now;
            //objBurnDown.PointsCompleted = 1;
            //objBurnDown.PointsPending = 1;

            //_context.DailyBurnDown.Add(objBurnDown);
            //_context.SaveChanges();

            //Act
            var response = await _client.GetAsync("api/Dashboard/GetBurnDownData");
            var IssuesList = await response.Content.ReadAsAsync<List<DailyBurnDownVm>>();

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            IssuesList.Should().NotBeEmpty();
        }   

        [Fact]
        public async Task Put_ValidRequest_SuccessfullyUpdatesIssuePriority()
        {
            //Arrange
            var issuePriority = new UpdateIssuePriorityCommand
            {
                PrevItem = true,
                PrevItemId = 2,
                NextItemId = 4,
                CurrentItemIndex = 10,
                IssueStatus = 1,
                IssueId = 55
            };

            //Act
            var response = await _client.PutAsJsonAsync("api/Dashboard/UpdateIssuePriority", issuePriority);
            var result = await response.Content.ReadAsAsync<bool>();

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().Be(true);
        }
        [Fact]
        public async Task Put_InValidRequest_ReturnsFailure()
        {
            //Arrange
            var issuePriority = new UpdateIssuePriorityCommand
            {
                PrevItem = true,
                PrevItemId=2,
                NextItemId=4,
                CurrentItemIndex=10,
                IssueStatus=1,
                IssueId=10
            };
            //Act
            var response = await _client.PutAsJsonAsync("api/Dashboard/UpdateIssuePriority", issuePriority);
            var result = await response.Content.ReadAsAsync<object>();

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            result.ToString().Should().Contain("One or more validation failures have occurred.");
        }
    }
}
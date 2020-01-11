using AutoMapper;
using DataAccess.DataModels;
using DataAccess.Models;
using ServiceModel.Dto;
using System;
using Xunit;

namespace UnitTest.Logic
{
    public class MappingTest : IClassFixture<MappingTestsFixture>
    {
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;
        public MappingTest(MappingTestsFixture fixture)
        {
            _configuration = fixture.ConfigurationProvider;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public void ShoulHaveValidConfiguration()
        {
            _configuration.AssertConfigurationIsValid();
        }

        [Theory]
        [InlineData(typeof(CreateIssueRequest), typeof(Issue))]
        [InlineData(typeof(CreateIssueTypeRequest), typeof(IssueType))]
        [InlineData(typeof(CreateIssueStatusRequest), typeof(IssueStatus))]
        [InlineData(typeof(EditIssueStatusRequest), typeof(IssueStatus))]
        [InlineData(typeof(RegisterUserRequest), typeof(AppUser))]
        public void ShouldSupportMappingFromSouceToDestination(Type source, Type destination)
        {
            var instance = Activator.CreateInstance(source);
            _mapper.Map(instance, source, destination);
        }
    }
}

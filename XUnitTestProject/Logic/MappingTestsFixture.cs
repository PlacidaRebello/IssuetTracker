using AutoMapper;
using IssueTracker.ApiConfig;
using System;
using System.Collections.Generic;
using System.Text;


namespace XUnitTestProject.Logic
{
    public class MappingTestsFixture
    {
        public IConfigurationProvider ConfigurationProvider { get; }
        public IMapper Mapper { get; }
        public MappingTestsFixture()
        {
            ConfigurationProvider = new MapperConfiguration(cfg => 
            {
                  cfg.AddProfile<AutoMapping>();
            });
            Mapper = ConfigurationProvider.CreateMapper();
        }
    }
}

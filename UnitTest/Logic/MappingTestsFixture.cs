using AutoMapper;
using IssueTracker.ApiConfig;

namespace UnitTest.Logic
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

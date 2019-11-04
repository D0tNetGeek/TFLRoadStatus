using Autofac;
using TFLRoadStatus.API.Interfaces;
using Xunit;

namespace TFLRoadStatus.Integration.Tests
{
    public class ConfigTest
    {
        private readonly IConfig _config;

        public ConfigTest()
        {
            _config = TFLRoadStatusContainer.Container.Resolve<IConfig>();
        }

        [Fact]
        public void When_Config_Is_Instantiated_Then_Correct_Values_Are_Found()
        {
            var expectedUrl = "http://api.tfl.gov.uk/Road/";
            var expectedAppId = "bc00d3e7";
            var expectedAppKey = "5012b3bec3afacd56b713cc06d26a52d	";

            Assert.NotNull(_config);
            Assert.Equal(expectedUrl, _config.Url);
            Assert.Equal(expectedAppId, _config.AppId);
            Assert.Equal(expectedAppKey, _config.AppKey);
        }
    }
}

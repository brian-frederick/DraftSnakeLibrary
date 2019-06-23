using DraftSnakeLibrary.Repositories;
using DraftSnakeLibrary.Services.Configurations;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace DraftSnakeLibraryTests.ConfigurationsTests
{
    public class ConfigurationServiceTests
    {
        [Fact]
        public async void RetrieveParameters_Scenario_RetrievesCorrectParameter()
        {
            // arrange
            var _configurationRepository = new Mock<IConfigurationRepository>();

            var configurationService = new ConfigurationService(_configurationRepository.Object);

            // Act
            await configurationService.RetrieveParameters(new List<string>() { "test" });

            // Assert
            _configurationRepository.Verify(
                cfg => cfg.RetrieveParameters(It.Is<List<string>>(x => x[0] == "test")),
                Times.Once);
        }

    }
}

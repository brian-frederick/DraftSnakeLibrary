using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;


namespace DraftSnakeLibraryTests.ConfigurationsTests
{
    public class ConfigurationsTests
    {
        [Fact]
        public async void RetrieveParameter_Scenario_RetrievesCorrectParameter()
        {
            // arrange
            var _ssmClient = new Mock<IAmazonSimpleSystemsManagement>();
            var param = new Parameter();
            param.Name = "test";
            param.Value = "test_value";
            var parametersResponse = new GetParametersResponse();
            parametersResponse.Parameters.Add(param);
            var paramsList = new List<string>() { "test" };

            _ssmClient.Setup(
                ssm => ssm.GetParametersAsync(It.IsAny<GetParametersRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(parametersResponse);

            var configurationRepository = new ConfigurationRepository(_ssmClient.Object);
            
            // Act
            var response = await configurationRepository.RetrieveParameters(paramsList);


            // Assert
            Assert.Equal("test_value", response[response.FindIndex(p => p.Name == "test")].Value);
        }
    }
}

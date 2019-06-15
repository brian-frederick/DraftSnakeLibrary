using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;

namespace DraftSnakeLibraryTests.ConfigurationsTests
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        IAmazonSimpleSystemsManagement _ssmClient;

        public ConfigurationRepository(IAmazonSimpleSystemsManagement ssmClient)
        {
            _ssmClient = ssmClient;
        }

        public async Task<List<Parameter>> RetrieveParameters(List<string> paramNames)
        {
            Console.WriteLine($"Retrieving params.");

            var paramRequest = new GetParametersRequest
            {
                Names = paramNames
            };

            var response = await _ssmClient.GetParametersAsync(paramRequest);

            Console.WriteLine("parameters retrieved:", response.Parameters.ToString());

            return response.Parameters;
        }
    }
}
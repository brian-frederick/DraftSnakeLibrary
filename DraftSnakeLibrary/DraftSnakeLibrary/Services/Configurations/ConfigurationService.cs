
using Amazon.SimpleSystemsManagement.Model;
using DraftSnakeLibrary.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DraftSnakeLibrary.Services.Configurations
{
    public class ConfigurationService : IConfigurationService
    {
        public IConfigurationRepository _configurationRepository;

        public ConfigurationService(IConfigurationRepository configurationRepository)
        {
            _configurationRepository = configurationRepository;
        }

        public async Task<List<Parameter>> RetrieveParameters(List<string> paramsList)
        {
            return await _configurationRepository.RetrieveParameters(paramsList);
        }
    }
}
using Amazon.SimpleSystemsManagement.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DraftSnakeLibraryTests.ConfigurationsTests
{
    public interface IConfigurationRepository
    {
        Task<List<Parameter>> RetrieveParameters(List<string> paramNames);
    }
}
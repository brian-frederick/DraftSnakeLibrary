using Amazon.SimpleSystemsManagement.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DraftSnakeLibrary.Services.Configurations
{
    public interface IConfigurationService
    {
        Task<List<Parameter>> RetrieveParameters(List<string> paramsList);
    }
}
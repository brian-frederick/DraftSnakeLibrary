using Amazon.SimpleSystemsManagement.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DraftSnakeLibrary.Repositories
{
    public interface IConfigurationRepository
    {
        Task<List<Parameter>> RetrieveParameters(List<string> paramNames);
    }
}
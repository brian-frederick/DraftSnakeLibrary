using DraftSnakeLibrary.Models.Picks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DraftSnakeLibrary.Repositories
{
    public class PickRepository : IModelDynamoDbRepository<Pick>
    {
        public async Task<List<Pick>> RetrieveByDraftId(string draftId)
        {
            throw new NotImplementedException();
        }

        public async Task<Pick> Put(Pick newPick)
        {
            throw new NotImplementedException();
        }
    }
}

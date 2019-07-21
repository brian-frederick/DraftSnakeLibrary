using DraftSnakeLibrary.Models.Picks;
using DraftSnakeLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DraftSnakeLibrary.Services.Picks
{
    public class PickService : IPickService
    {
        IModelDynamoDbRepository<Pick> _pickRepository;

        public PickService(IModelDynamoDbRepository<Pick> pickRepository)
        {
            _pickRepository = pickRepository;
        }

        public async Task<List<Pick>> Retrieve(string draftId)
        {
            return await _pickRepository.RetrieveByDraftId(draftId);
        }

        public async Task<Pick> Put(Pick newPick)
        {
            if (newPick.Id < 1)
            {
                newPick.Id = await GetNextIdByDraft(newPick.DraftId);
            }

            return await _pickRepository.Put(newPick);
        }

        public async Task<int> GetNextIdByDraft(string draftId)
        {
            var highestPick = await _pickRepository.RetrieveByDraftId(draftId, true, 1);

            var highestPickId = highestPick.Count > 0 ? highestPick[0].Id :  0;

            return highestPickId + 1;
        }
    }
}

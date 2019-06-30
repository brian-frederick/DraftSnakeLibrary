using DraftSnakeLibrary.Models.Picks;
using DraftSnakeLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DraftSnakeLibrary.Services.Picks
{
    public class PickService
    {
        IModelDynamoDbRepository<Pick> _pickRepository;

        public PickService(IModelDynamoDbRepository<Pick> pickRepository)
        {
            _pickRepository = pickRepository;
        }

        public async Task<List<Pick>> RetrieveByDraftId(string draftId)
        {
            return await _pickRepository.RetrieveByDraftId(draftId);
        }

        public async Task<Pick> Put(Pick newPick)
        {
            return await _pickRepository.Put(newPick);
        }

    }
}

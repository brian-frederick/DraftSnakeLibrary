using DraftSnakeLibrary.Models.Players;
using DraftSnakeLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DraftSnakeLibrary.Services.Players
{
    public class PlayerService : IPlayerService
    {
        IModelDynamoDbRepository<Player> _playerRepository;

        public PlayerService(IModelDynamoDbRepository<Player> playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<List<Player>> RetrievePlayers(string draftId)
        {
            return await _playerRepository.RetrieveByDraftId(draftId);
        }

        public Task<Player> Put(Player playerToPut)
        {
            return _playerRepository.Put(playerToPut);
        }
    }
}

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
        IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<List<Player>> RetrievePlayers(string draftId)
        {
            return await _playerRepository.RetrievePlayers(draftId);
        }
    }
}

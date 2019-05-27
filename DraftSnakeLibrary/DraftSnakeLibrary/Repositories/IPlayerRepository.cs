using DraftSnakeLibrary.Models.Players;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DraftSnakeLibrary.Repositories
{
    public interface IPlayerRepository
    {
        Task<List<Player>> RetrievePlayers(string draftId);
    }
}

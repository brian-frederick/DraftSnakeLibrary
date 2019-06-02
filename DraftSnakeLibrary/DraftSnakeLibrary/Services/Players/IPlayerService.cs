using DraftSnakeLibrary.Models.Players;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DraftSnakeLibrary.Services.Players
{
    public interface IPlayerService
    {
        Task<List<Player>> RetrievePlayers(string draftId);
    }
}
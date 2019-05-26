using DraftSnakeLibrary.Entities.Players;

namespace DraftSnakeLibrary.Services.Players
{
    public interface IPlayerService
    {
        Player RetrievePlayers(string draftId);
    }
}
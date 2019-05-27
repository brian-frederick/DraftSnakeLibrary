using System;
using Xunit;
using DraftSnakeLibrary.Services.Players;
using DraftSnakeLibrary.Models.Players;

namespace DraftSnakeLibraryTests
{
    public class PlayerServiceTests
    {
        [Fact]
        public void Test1()
        {
            var PlayerService = new PlayerService();

            var expectedPlayer = new Player();
            var actualPlayer = PlayerService.RetrievePlayers("test");

            Assert.Equal(expectedPlayer, actualPlayer);
        }
    }
}

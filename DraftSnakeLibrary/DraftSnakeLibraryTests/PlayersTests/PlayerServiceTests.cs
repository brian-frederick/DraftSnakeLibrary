using System;
using Xunit;
using DraftSnakeLibrary.Services.Players;
using DraftSnakeLibrary.Models.Players;
using Moq;
using DraftSnakeLibrary.Repositories;
using System.Collections.Generic;

namespace DraftSnakeLibraryTests
{
    public class PlayerServiceTests
    {
        [Fact]
        public async void RetrievePlayersTest_Scenario_ReturnsPlayers()
        {
            var _playerRepository = new Mock<IPlayerRepository>();
            var expectedPlayers = new List<Player>()
            {
              new Player(){ Name = "test", DraftId = "test", ConnectionId = "test", IsConnected = true }
            };

            _playerRepository.Setup(pr => pr.RetrievePlayers(It.IsAny<string>())).ReturnsAsync(expectedPlayers);

            var playerService = new PlayerService(_playerRepository.Object);

            var result = await playerService.RetrievePlayers("test");

            Assert.Equal(expectedPlayers, result);
        }
    }
}

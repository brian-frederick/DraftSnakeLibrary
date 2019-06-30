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
        public async void RetrievePlayersTest_Scenario_ReturnsPlayersByDraftId()
        {
            var _playerRepository = new Mock<IModelDynamoDbRepository<Player>>();
            var expectedPlayers = new List<Player>()
            {
              new Player(){ Name = "test", DraftId = "test", ConnectionId = "test", IsConnected = true }
            };

            _playerRepository.Setup(pr => 
                pr.RetrieveByDraftId(It.IsAny<string>()))
                    .ReturnsAsync(expectedPlayers);

            var playerService = new PlayerService(_playerRepository.Object);

            var result = await playerService.RetrievePlayers("test");

            Assert.Equal(expectedPlayers, result);
        }

        [Fact]
        public async void PutTest_Scenario_PutsPlayer()
        {
            var _playerRepository = new Mock<IModelDynamoDbRepository<Player>>();
            var playerToPut = new Player() { Name = "test", DraftId = "test", ConnectionId = "test", IsConnected = true };

            var playerService = new PlayerService(_playerRepository.Object);

            await playerService.Put(playerToPut);

            _playerRepository.Verify(x => x.Put(playerToPut), Times.Once);
        }
    }
}

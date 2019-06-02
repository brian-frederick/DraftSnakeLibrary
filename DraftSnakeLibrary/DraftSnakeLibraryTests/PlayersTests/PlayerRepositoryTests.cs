using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using DraftSnakeLibrary.Models.Players;
using DraftSnakeLibrary.Repositories;
using DraftSnakeLibrary.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace DraftSnakeLibraryTests.PlayersTests
{
    public class PlayerRepositoryTests
    {
        [Fact]
        public async void RetrievePlayersTest_Scenario_ReturnsPlayers()
        {

            var _dynamoClient = new Mock<IAmazonDynamoDB>();
            var _playerMapper = new Mock<IModelMapper<Player>>();

            var dynamoQueryResponse = new QueryResponse();
            var expectedPlayer = new Player();

            dynamoQueryResponse.Items.Add(new Dictionary<string, AttributeValue>
            {
                { "DraftId", new AttributeValue{ S = "test" } },
                { "Name", new AttributeValue{ S = "test" } },
                { "ConnectionId", new AttributeValue{ S = "test" } },
                { "IsConnected", new AttributeValue{ BOOL = false } }
            });

            _dynamoClient.
                Setup(x => x.QueryAsync(It.IsAny<QueryRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(dynamoQueryResponse);

            _playerMapper
                .Setup(pm => pm.MapDynamoItemToModel(It.IsAny<Dictionary<string, AttributeValue>>()))
                .Returns(expectedPlayer);

            var playerRepository = new PlayerRepository(_dynamoClient.Object, _playerMapper.Object);

            var result = await playerRepository.RetrievePlayers("test");

            Assert.Equal(expectedPlayer, result[0]);

        }
    }
}

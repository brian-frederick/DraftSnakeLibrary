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
        public async void RetrievePlayersTest_Scenario_ReturnsPlayersFromDynamoClient()
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

            var result = await playerRepository.RetrieveByDraftId("test");

            Assert.Equal(expectedPlayer, result[0]);
        }

        [Fact]
        public async void PutTest_Scenario_PutsPlayerInDynamoClient()
        {
            var expectedPlayer = new Player() { Name = "test", DraftId = "test", ConnectionId = "test", IsConnected = true };
            var expectedRequest = new PutItemRequest
            {
                TableName = "Players",
                Item = new Dictionary<string, AttributeValue>
                    {
                        { "DraftId", new AttributeValue{ S = expectedPlayer.DraftId }},
                        { "Name", new AttributeValue{S = expectedPlayer.Name} },
                        { "ConnectionId", new AttributeValue{ S = expectedPlayer.ConnectionId }},
                        { "IsConnected", new AttributeValue{ BOOL = expectedPlayer.IsConnected } }
                    }
            };

            var _dynamoClient = new Mock<IAmazonDynamoDB>();
            var _playerMapper = new Mock<IModelMapper<Player>>();

            var playerRepository = new PlayerRepository(_dynamoClient.Object, _playerMapper.Object);

            await playerRepository.Put(expectedPlayer);

            _dynamoClient.Verify(dc => 
                dc.PutItemAsync(It.Is<PutItemRequest>(req => req.Item["Name"].S == "test"), It.IsAny<CancellationToken>()),
                Times.Once);
        }
    }
}

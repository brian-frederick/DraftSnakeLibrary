using Amazon.DynamoDBv2.Model;
using DraftSnakeLibrary.Models.Players;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DraftSnakeLibraryTests.PlayersTests
{
    public class PlayerMapperTests
    {

        [Fact]
        public void MapDynamoItemToModel_Scenario_ReturnsPlayerFromItem()
        {
            var draftId = "AAA";
            var name = "Tester";
            var connectionId = "123abc";
            var isConnected = false;

            var item = new Dictionary<string, AttributeValue>
            {
                { "DraftId", new AttributeValue{ S = draftId } },
                { "Name", new AttributeValue{ S = name } },
                { "ConnectionId", new AttributeValue{ S = connectionId } },
                { "IsConnected", new AttributeValue{ BOOL = isConnected } }
            };

            var _playerMapper = new PlayerMapper();
            var result = _playerMapper.Map(item);

            Assert.Equal(draftId, result.DraftId);
            Assert.Equal(name, result.Name);
            Assert.Equal(connectionId, result.ConnectionId);
            Assert.Equal(isConnected, result.IsConnected);
        }
    }
}

using Amazon.DynamoDBv2.Model;
using DraftSnakeLibrary.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DraftSnakeLibrary.Models.Players
{

    public class PlayerMapper : IDynamoMapper<Player>
    {
        public Player Map(Dictionary<string, AttributeValue> item)
        {
            var player = new Player()
            {
                DraftId = item["DraftId"]?.S,
                Name = item["Name"]?.S,
                ConnectionId = item["ConnectionId"]?.S,
                IsConnected = item["IsConnected"]?.BOOL ?? false
            };

            return player;
        }

        public Dictionary<string, AttributeValue> Map(Player player)
        {
            throw new NotImplementedException();
        }
    }
}

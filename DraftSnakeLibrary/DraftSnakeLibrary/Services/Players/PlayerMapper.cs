using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DraftSnakeLibrary.Models.Players
{

    public class PlayerMapper 
    {
        public Player MapDynamoItemToModel(Dictionary<string, AttributeValue> item)
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
    }
}

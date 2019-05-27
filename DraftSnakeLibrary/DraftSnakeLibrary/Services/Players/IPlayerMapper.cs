using Amazon.DynamoDBv2.Model;
using DraftSnakeLibrary.Models.Players;
using System;
using System.Collections.Generic;
using System.Text;

namespace DraftSnakeLibrary.Services.Players
{
    public interface IPlayerMapper
    {
        Player MapDynamoItemToModel(Dictionary<string, AttributeValue> item);
    }
}

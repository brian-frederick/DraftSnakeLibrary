﻿using DraftSnakeLibrary.Models.Players;
using System;
using System.Collections.Generic;
using System.Text;
using Amazon.DynamoDBv2.Model;
using Amazon.DynamoDBv2;
using System.Threading.Tasks;
using DraftSnakeLibrary.Services.Players;
using DraftSnakeLibrary.Services;

namespace DraftSnakeLibrary.Repositories
{
    public class PlayerRepository : IModelDynamoDbRepository<Player>
    {
        IAmazonDynamoDB _dynamoClient;
        IModelMapper<Player> _playerMapper;

        public PlayerRepository(IAmazonDynamoDB dynamoClient, IModelMapper<Player> playerMapper)
        {
            _dynamoClient = dynamoClient;
            _playerMapper = playerMapper;
        }


        public async Task<List<Player>> RetrieveByDraftId(string draftId)
        {
            var request = new QueryRequest
            {
                TableName = "Players",
                KeyConditionExpression = "DraftId = :v_DraftId",
                ExpressionAttributeValues = new Dictionary<string, AttributeValue> {
                    {":v_DraftId", new AttributeValue { S = draftId }},
                },
            };

            var scanResponse = await _dynamoClient.QueryAsync(request);

            var players = new List<Player>();

            scanResponse.Items.ForEach(item =>
            {
                players.Add(
                    _playerMapper.MapDynamoItemToModel(item)
                 );
            });

            return players;
        }

        public async Task<Player> Put(Player newPlayer)
        {
            var ddbRequest = new PutItemRequest
            {
                TableName = "Players",
                Item = new Dictionary<string, AttributeValue>
                    {
                        { "DraftId", new AttributeValue{ S = newPlayer.DraftId }},
                        { "Name", new AttributeValue{S = newPlayer.Name} },
                        { "ConnectionId", new AttributeValue{ S = newPlayer.ConnectionId }},
                        { "IsConnected", new AttributeValue{ BOOL = newPlayer.IsConnected } }
                    }
            };

            await _dynamoClient.PutItemAsync(ddbRequest);

            return newPlayer;
        }
    }
}

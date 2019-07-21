using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using DraftSnakeLibrary.Models.Picks;
using DraftSnakeLibrary.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DraftSnakeLibrary.Repositories
{
    public class PickRepository : IModelDynamoDbRepository<Pick>
    {
        private string _tableName = "Picks";
        IAmazonDynamoDB _dynamoClient;
        IModelMapper<Pick> _pickMapper;

        public PickRepository(IAmazonDynamoDB dynamoClient, IModelMapper<Pick> pickMapper)
        {
            _dynamoClient = dynamoClient;
            _pickMapper = pickMapper;
        }

        public async Task<List<Pick>> RetrieveByDraftId(string draftId)
        {
            return await RetrieveByDraftId(draftId, false, null);
        }

        public async Task<List<Pick>> RetrieveByDraftId(string draftId, bool descendingOrder, int? limit)
        {
            var request = new QueryRequest
            {
                TableName = _tableName,
                KeyConditionExpression = "DraftId = :v_DraftId",
                ExpressionAttributeValues = new Dictionary<string, AttributeValue> {
                        {":v_DraftId", new AttributeValue { S = draftId }},
                }
            };

            if (descendingOrder)
            {
                request.ScanIndexForward = false;
            }

            if (limit.HasValue)
            {
                request.Limit = limit.Value;
            }

            var scanResponse = await _dynamoClient.QueryAsync(request);

            var picks = new List<Pick>();

            scanResponse.Items.ForEach(item =>
            {
                picks.Add(
                    _pickMapper.MapDynamoItemToModel(item)
                );
            });

            return picks;
        }

        public async Task<Pick> Put(Pick newPick)
        {
            var ddbRequest = new PutItemRequest
            {
                TableName = _tableName,
                Item = new Dictionary<string, AttributeValue>
                {
                    { "DraftId", new AttributeValue{ S = newPick.DraftId }},
                    { "Id", new AttributeValue{N = newPick.Id.ToString() } },
                    { "PlayerId", new AttributeValue{ S = newPick.PlayerId }},
                    { "Selection", new AttributeValue{ S = newPick.Selection } }
                },
            };

            await _dynamoClient.PutItemAsync(ddbRequest);

            return newPick;
        }


    }
}

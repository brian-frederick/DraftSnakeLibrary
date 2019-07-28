using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using DraftSnakeLibrary.Models.Drafts;
using DraftSnakeLibrary.Repositories;
using DraftSnakeLibrary.Services;
using Moq;

namespace DraftSnakeLibraryTests.DraftsTests
{
    public class DraftRepository: IModelDynamoDbRepository<Draft>
    {
        private string _tableName = "Drafts";
        private IAmazonDynamoDB _dynamoClient;
        private IDynamoMapper<Draft> _draftMapper;

        public DraftRepository(IAmazonDynamoDB dynamoClient, IDynamoMapper<Draft> draftMapper)
        {
            _dynamoClient = dynamoClient;
            _draftMapper = draftMapper;
        }

        public async Task<Draft> Put(Draft draft)
        {
            var requestItem = _draftMapper.Map(draft);

            var ddbRequest = new PutItemRequest
            {
                TableName = _tableName,
                Item = requestItem
            };

            await _dynamoClient.PutItemAsync(ddbRequest);

            return draft;
        }

        public Task<List<Draft>> RetrieveByDraftId(string draftId, bool descendingOrder, int? limit)
        {
            throw new NotImplementedException();
        }

        public Task<List<Draft>> RetrieveByDraftId(string draftId)
        {
            throw new NotImplementedException();
        }
    }
}
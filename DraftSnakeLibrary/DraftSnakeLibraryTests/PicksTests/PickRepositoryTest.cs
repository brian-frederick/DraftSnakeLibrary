using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using DraftSnakeLibrary.Models.Picks;
using DraftSnakeLibrary.Repositories;
using DraftSnakeLibrary.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace DraftSnakeLibraryTests.PicksTests
{
    public class PickRepositoryTest
    {
        [Fact]
        public async void RetrievePicksTest_Scenario_ReturnsPicksFromDynamoClientWithOnlyDraftIdParam()
        {
            var _dynamoClient = new Mock<IAmazonDynamoDB>();
            var _pickMapper = new Mock<IModelMapper<Pick>>();

            var dynamoQueryResponse = new QueryResponse();
            var expectedPick = new Pick();

            dynamoQueryResponse.Items.Add(new Dictionary<string, AttributeValue>
            {
                { "DraftId", new AttributeValue{ S = "test" }},
                { "Id", new AttributeValue{N = "1" } },
                { "PlayerId", new AttributeValue{ S = "test player id" }},
                { "Selection", new AttributeValue{ S = "test selection" } }
            });

            _dynamoClient
                .Setup(x => x.QueryAsync(It.IsAny<QueryRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(dynamoQueryResponse);

            _pickMapper
                .Setup(pm => pm.MapDynamoItemToModel(It.IsAny<Dictionary<string, AttributeValue>>()))
                .Returns(expectedPick);

            var pickRepository = new PickRepository(_dynamoClient.Object, _pickMapper.Object);

            var result = await pickRepository.RetrieveByDraftId("testDraftId");

            Assert.Equal(expectedPick, result[0]);

            _dynamoClient.Verify(dc =>
               dc.QueryAsync(It.IsAny<QueryRequest>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async void RetrievePicksTest_Scenario_ReturnsPicksFromDynamoClientWithLimitAndDescending()
        {
            var _dynamoClient = new Mock<IAmazonDynamoDB>();
            var _pickMapper = new Mock<IModelMapper<Pick>>();

            var dynamoQueryResponse = new QueryResponse();
            var expectedPick = new Pick();

            dynamoQueryResponse.Items.Add(new Dictionary<string, AttributeValue>
            {
                { "DraftId", new AttributeValue{ S = "test" }},
                { "Id", new AttributeValue{N = "1" } },
                { "PlayerId", new AttributeValue{ S = "test player id" }},
                { "Selection", new AttributeValue{ S = "test selection" } }
            });

            _dynamoClient
                .Setup(x => x.QueryAsync(It.IsAny<QueryRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(dynamoQueryResponse);

            _pickMapper
                .Setup(pm => pm.MapDynamoItemToModel(It.IsAny<Dictionary<string, AttributeValue>>()))
                .Returns(expectedPick);

            var pickRepository = new PickRepository(_dynamoClient.Object, _pickMapper.Object);

            var result = await pickRepository.RetrieveByDraftId("testDraftId", true, 1);

            Assert.Equal(expectedPick, result[0]);

            _dynamoClient.Verify(dc =>
               dc.QueryAsync(It.Is<QueryRequest>(req => req.ScanIndexForward == false && req.Limit == 1), It.IsAny<CancellationToken>()), 
                Times.Once);
        }

        [Fact]
        public async void PutTest_Scenario_PutsPickInDynamoClient()
        {
            var pickToAdd = new Pick()
            {
                DraftId = "testDraftId",
                Id = 1,
                PlayerId = "testId",
                Selection = "potato wedges"
            };

            var expectedRequest = new PutItemRequest
            {
                TableName = "Picks",
                Item = new Dictionary<string, AttributeValue>
                {
                    { "DraftId", new AttributeValue{ S = "test" }},
                    { "Id", new AttributeValue{N = "1" }},
                    { "PlayerId", new AttributeValue{ S = "test player id" }},
                    { "Selection", new AttributeValue{ S = "test selection" }}
                }
            };

            var _dynamoClient = new Mock<IAmazonDynamoDB>();
            var _pickMapper = new Mock<IModelMapper<Pick>>();

            var pickRepository = new PickRepository(_dynamoClient.Object, _pickMapper.Object);

            await pickRepository.Put(pickToAdd);

            _dynamoClient.Verify(dc => 
                dc.PutItemAsync(It.Is<PutItemRequest>(req => req.Item["Selection"].S == pickToAdd.Selection), It.IsAny<CancellationToken>()),
                Times.Once);
        }
    }
}

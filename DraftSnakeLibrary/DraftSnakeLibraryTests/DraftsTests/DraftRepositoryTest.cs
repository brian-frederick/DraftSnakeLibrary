using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using DraftSnakeLibrary.Models.Drafts;
using DraftSnakeLibrary.Repositories;
using DraftSnakeLibrary.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace DraftSnakeLibraryTests.DraftsTests
{
    public class DraftRepositoryTest
    {
        [Fact]
        public async void PutDraft_Scenario_PutsPlayerInDynamoClient()
        {
            var expectedDraft = new Draft()
            {
                Id = "111",
                Description = "Top ten tests",
                Type = DraftType.Socket,
                Stage = DraftStage.AwaitingPlayers
            };

            var expectedDynamoItem = new Dictionary<string, AttributeValue>
            {
                { "Id", new AttributeValue{ S = "111"} },
                { "Description", new AttributeValue{ S = "Top ten tests"} },
                { "Type", new AttributeValue{ N = "1"} },
                { "Stage", new AttributeValue{ N = "1"} }
            };

            var _dynamoClient = new Mock<IAmazonDynamoDB>();
            var _draftMapper = new Mock<IDynamoMapper<Draft>>();

            _draftMapper.Setup(dm => dm.Map(It.Is<Draft>(d => d.Id == "111")))
                .Returns(expectedDynamoItem);

            var draftRepository = new DraftRepository(_dynamoClient.Object, _draftMapper.Object);

            await draftRepository.Put(expectedDraft);

            _draftMapper.Verify(dm => dm.Map(expectedDraft), Times.Once);
            _dynamoClient.Verify(dc => dc.PutItemAsync(It.Is<PutItemRequest>(req => req.Item["Id"].S == "111"), It.IsAny<CancellationToken>()),
                Times.Once);
        }
    }
}

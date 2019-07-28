using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using DraftSnakeLibrary.Models.Drafts;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DraftSnakeLibraryTests.DraftsTests
{
    public class DraftMapperTests
    {
        [Fact]
        public void Map_Scenario_MapsDraftToDynamoItem()
        {
            var expectedDraft = new Draft()
            {
                Id = "111",
                Description = "Top ten tests",
                Type = DraftType.Socket,
                Stage = DraftStage.Drafting
            };

            var expectedDynamoItem = new Dictionary<string, AttributeValue>
            {
                { "Id", new AttributeValue{ S = "111"} },
                { "Description", new AttributeValue{ S = "Top ten tests"} },
                { "Type", new AttributeValue{ N = "1"} },
                { "Stage", new AttributeValue{ N = "1"} }
            };

            var draftMapper = new DraftMapper();

            var result = draftMapper.Map(expectedDraft);

            Assert.Equal(expectedDraft.Id, result["Id"].S);
            Assert.Equal(expectedDraft.Description, result["Description"].S);
            Assert.Equal("1", result["Type"].N);
            Assert.Equal("2", result["Stage"].N); 


        }
    }
}

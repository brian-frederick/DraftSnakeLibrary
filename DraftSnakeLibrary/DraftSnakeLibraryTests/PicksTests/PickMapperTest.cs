using Amazon.DynamoDBv2.Model;
using DraftSnakeLibrary.Services.Picks;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DraftSnakeLibraryTests.PicksTests
{
    public class PickMapperTest
    {
        [Fact]
        public void MayDynamoItemToModel_Scenario_ReturnsPickFromItem()
        {
            var draftId = "TEST";
            var overallOrder = 3;
            var playerId = "tester";
            var selection = "gnocchi";

            var item = new Dictionary<string, AttributeValue>
            {
                { "DraftId", new AttributeValue{ S = draftId} },
                { "Id", new AttributeValue {N = overallOrder.ToString()} },
                { "PlayerId", new AttributeValue {S = playerId} },
                { "Selection", new AttributeValue {S = selection} }
            };

            var pickMapper = new PickMapper();

            var result = pickMapper.MapDynamoItemToModel(item);

            Assert.Equal(draftId, result.DraftId);
            Assert.Equal(overallOrder, result.Id);
            Assert.Equal(playerId, result.PlayerId);
            Assert.Equal(selection, result.Selection);
        }

    }
}

using System;
using System.Collections.Generic;
using Amazon.DynamoDBv2.Model;
using DraftSnakeLibrary.Models.Drafts;
using DraftSnakeLibrary.Services;

namespace DraftSnakeLibraryTests.DraftsTests
{
    public class DraftMapper : IDynamoMapper<Draft>
    {

        public Draft Map(Dictionary<string, AttributeValue> item)
        {
            throw new System.NotImplementedException();
        }

        public Dictionary<string, AttributeValue> Map(Draft draft)
        {
            var draftDynamoItem =  new Dictionary<string, AttributeValue>
            {
                { "Id", new AttributeValue{ S = draft.Id} },
                { "Description", new AttributeValue{ S = draft.Description} },
                { "Type", new AttributeValue{ N = Convert.ToString((int)draft.Type)} },
                { "Stage", new AttributeValue{ N = Convert.ToString((int)draft.Stage)} }
            };

            return draftDynamoItem;
        }
    }
}
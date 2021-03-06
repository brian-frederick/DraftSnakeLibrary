﻿using Amazon.DynamoDBv2.Model;
using DraftSnakeLibrary.Models.Picks;
using System;
using System.Collections.Generic;
using System.Text;

namespace DraftSnakeLibrary.Services.Picks
{
    public class PickMapper : IDynamoMapper<Pick>
    {
        public Pick Map(Dictionary<string, AttributeValue> item)
        {
            var pick = new Pick()
            {
                DraftId = item["DraftId"]?.S,
                PlayerId = item["PlayerId"]?.S,
                Selection = item["Selection"]?.S
            };

            int overallOrder;
            int.TryParse(item["Id"]?.N, out overallOrder);

            pick.Id = overallOrder;

            return pick;
        }

        public Dictionary<string, AttributeValue> Map(Pick pick)
        {
            throw new NotImplementedException();
        }
    }
}

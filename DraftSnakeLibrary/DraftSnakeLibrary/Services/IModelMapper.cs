using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DraftSnakeLibrary.Services
{
    public interface IModelMapper<T>
    {
        T MapDynamoItemToModel(Dictionary<string, AttributeValue> item);
    }
}

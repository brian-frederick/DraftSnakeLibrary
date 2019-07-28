using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DraftSnakeLibrary.Services
{
    public interface IDynamoMapper<T>
    {
        T Map(Dictionary<string, AttributeValue> item);

        Dictionary<string, AttributeValue> Map(T model);
    }
}

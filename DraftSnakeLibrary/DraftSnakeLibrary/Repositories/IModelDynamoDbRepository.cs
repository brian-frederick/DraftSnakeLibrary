using DraftSnakeLibrary.Models.Players;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DraftSnakeLibrary.Repositories
{
    public interface IModelDynamoDbRepository<T>
    {
        Task<List<T>> RetrieveByDraftId(string draftId);

        Task<T> Put(T item);
    }
}

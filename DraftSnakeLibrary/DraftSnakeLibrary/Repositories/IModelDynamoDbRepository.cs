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

        Task<List<T>> RetrieveByDraftId(string draftId, bool descendingOrder, int? limit);

        Task<T> Put(T item);
    }
}

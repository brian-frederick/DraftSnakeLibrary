using DraftSnakeLibrary.Models.Picks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DraftSnakeLibrary.Services.Picks
{
    public interface IPickService
    {
        Task<List<Pick>> Retrieve(string draftId);

        Task<Pick> Put(Pick newPick);

        Task<int> GetNextIdByDraft(string draftId);
    }
}

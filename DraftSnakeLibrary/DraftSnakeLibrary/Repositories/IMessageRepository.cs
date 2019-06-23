using Amazon.SQS.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DraftSnakeLibrary.Repositories
{
    public interface IMessageRepository<T>
    {
        Task<T> SendMessage(T message);
    }
}

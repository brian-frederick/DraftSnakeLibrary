using System.Threading.Tasks;

namespace DraftSnakeLibrary.Services.Messages
{
    public interface IMessageService<T>
    {
        Task<T> SendMessage(T message);
    }
}
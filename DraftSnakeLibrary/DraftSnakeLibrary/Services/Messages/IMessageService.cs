using System.Threading.Tasks;

namespace DraftSnakeLibraryTests.MessagesTest
{
    public interface IMessageService<T>
    {
        Task<T> SendMessage(T message);
    }
}
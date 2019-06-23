using DraftSnakeLibrary.Repositories;
using DraftSnakeLibrary.Services.Messages;
using System.Threading.Tasks;

namespace DraftSnakeLibrary.Services.Messages
{
    public class MessageService<T> : IMessageService<T>
    {
        public IMessageRepository<T> _messageRepository;

        public MessageService(IMessageRepository<T> messageRepository)
        {
            _messageRepository = messageRepository;
        }
          
        public async Task<T> SendMessage(T message)
        {
            return await _messageRepository.SendMessage(message);
        }
    }
}
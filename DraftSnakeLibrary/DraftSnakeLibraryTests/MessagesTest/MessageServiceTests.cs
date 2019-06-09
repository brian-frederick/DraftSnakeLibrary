using DraftSnakeLibrary.Models.Messages;
using DraftSnakeLibrary.Repositories.MessageRepository;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DraftSnakeLibraryTests.MessagesTest
{
    public class MessageServiceTests
    {
        [Fact]
        public async void SendMessage_Scenario_SendsMessageToRepository()
        {
            // arrange
            var _messageRepository = new Mock<IMessageRepository<PlayerCreatedMessage>>();

            var messageService = new MessageService<PlayerCreatedMessage>(_messageRepository.Object);

            var message = new PlayerCreatedMessage();

            // Act
            await messageService.SendMessage(message);

            // Assert
            _messageRepository.Verify(
                sqs => sqs.SendMessage(It.Is<PlayerCreatedMessage>(m => m.MessageType == MessageType.PlayerCreated)),
                Times.Once);
        }
    }
}

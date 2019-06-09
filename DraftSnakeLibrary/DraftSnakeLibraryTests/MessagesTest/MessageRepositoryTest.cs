using DraftSnakeLibrary.Models.Messages;
using DraftSnakeLibrary.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Amazon.SQS;
using Amazon.SQS.Model;
using System.Threading;
using DraftSnakeLibrary.Repositories.MessageRepository;

namespace DraftSnakeLibraryTests.MessagesTest
{
    public class MessageRepositoryTest
    {
        [Fact]
        public async void SendMessage_Scenario_SendsMessage()
        {
            // arrange
            var expectedMessage = new PlayerCreatedMessage();

            var sqsConfig = new AmazonSQSConfig();
            sqsConfig.ServiceURL = "https://sqs.us-east-1.amazonaws.com";

            var _sqsClient = new Mock<AmazonSQSClient>(sqsConfig);

            _sqsClient.Setup(
                sqs => sqs.SendMessageAsync(It.IsAny<SendMessageRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new SendMessageResponse());

            var messageRepository = new MessageRepository<PlayerCreatedMessage>(_sqsClient.Object);

            // act
            await messageRepository.SendMessage(expectedMessage);

            // assert
            _sqsClient.Verify(
                sqs => sqs.SendMessageAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()),
                Times.Once);
          }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Amazon.SQS;
using Amazon.SQS.Model;
using DraftSnakeLibrary.Models.Messages;
using Newtonsoft.Json;

namespace DraftSnakeLibrary.Repositories.MessageRepository
{
    public class MessageRepository<T> : IMessageRepository<T>
    {   
        IAmazonSQS _amazonSQSClient;

        public MessageRepository(IAmazonSQS amazonSQSClient){
            _amazonSQSClient = amazonSQSClient;
        }

        public async Task<T> SendMessage(T message)
        {
            var queueUrl = "google.com";

            Console.WriteLine($"Sending message to {queueUrl} queue.");

            var messageBody = JsonConvert.SerializeObject(message);

            await _amazonSQSClient.SendMessageAsync(queueUrl, messageBody);

            Console.WriteLine("The following message was sent to queue:");
            Console.Write(messageBody);

            return message;
        }

    }
}

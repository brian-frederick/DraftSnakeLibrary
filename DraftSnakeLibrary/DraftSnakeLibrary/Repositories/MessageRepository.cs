using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Amazon.SQS;
using Amazon.SQS.Model;
using DraftSnakeLibrary.Models.Messages;
using Newtonsoft.Json;

namespace DraftSnakeLibrary.Repositories
{
    public class MessageRepository<T> : IMessageRepository<T>
    {
        private string _queueUrl = "https://sqs.us-east-1.amazonaws.com/628677708876/Web_Socket_Events";
        private string _serviceUrl = "https://sqs.us-east-1.amazonaws.com";
        IAmazonSQS _amazonSQSClient;

        public MessageRepository(IAmazonSQS amazonSQSClient){
            _amazonSQSClient = amazonSQSClient;
        }

        public async Task<T> SendMessage(T message)
        {
            var queueUrl = _queueUrl;

            Console.WriteLine($"Sending message to {queueUrl} queue.");

            var messageBody = JsonConvert.SerializeObject(message);

            await _amazonSQSClient.SendMessageAsync(_queueUrl, messageBody);

            Console.WriteLine("The following message was sent to queue:");
            Console.Write(messageBody);

            return message;
        }

    }
}

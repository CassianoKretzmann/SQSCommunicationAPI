using Amazon.Runtime;
using Amazon.SQS;
using Amazon.SQS.Model;
using SQSCommunicationAPI.Domain.DTO;
using SQSCommunicationAPI.Infra.CrossCuting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQSCommunicationAPI.Application
{
    public class SendMessageSQSApplication
    {
        public SendMessageSQSApplication() { }

        public async Task<SendMessageResponse> SendMessage(SendMessageDTO parameters)
        {
            var client = EnvironmentData.GetSQSClient();

            var request = new SendMessageRequest()
            {
                QueueUrl = EnvironmentData.QUEUE_URL,
                MessageBody = parameters.MessageBody,
                DelaySeconds = parameters.Delay
            };

            return await client.SendMessageAsync(request);
        }
    }
}

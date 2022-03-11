using Amazon;
using Amazon.Runtime;
using Amazon.SQS;
using Amazon.SQS.Model;
using Microsoft.Extensions.Hosting;
using SQSCommunicationAPI.Infra.CrossCuting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SQSCommunicationAPI.BackGroundProcessors
{
    public class SQSMessageProcessor : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("Starting background processor...");

            var client = EnvironmentData.GetSQSClient();

            while (!stoppingToken.IsCancellationRequested)
            {
                Console.WriteLine($"Getting messages from the queue {DateTime.Now}");
                var request = new ReceiveMessageRequest()
                {
                    QueueUrl = EnvironmentData.QUEUE_URL,
                    WaitTimeSeconds = EnvironmentData.WaitTime,
                    VisibilityTimeout = EnvironmentData.VisibilityTimeOut
                };

                var response = await client.ReceiveMessageAsync(request);
                foreach (var message in response.Messages)
                {
                    Console.WriteLine(message.Body);

                    //This can be a validation of type or something like that, the only purpose here is to test the DLQ
                    if (message.Body.Contains("Exception")) continue;

                    //Delete the message after reading.
                    await client.DeleteMessageAsync(EnvironmentData.QUEUE_URL, message.ReceiptHandle);
                }
            }
        }
    }
}

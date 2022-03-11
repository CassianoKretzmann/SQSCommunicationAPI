using Amazon.Runtime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQSCommunicationAPI.Infra.CrossCuting;
using Amazon.SQS;
using Amazon;
using Amazon.SQS.Model;
using SQSCommunicationAPI.Domain.DTO;
using SQSCommunicationAPI.Application;

namespace SQSCommunicationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SendMessageSQSController : ControllerBase
    {
        private readonly ILogger<SendMessageSQSController> _logger;

        public SendMessageSQSController(ILogger<SendMessageSQSController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task SendMessage(SendMessageDTO parameters)
        {
            _= await new SendMessageSQSApplication().SendMessage(parameters);
        }
    }
}

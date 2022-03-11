using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQSCommunicationAPI.Domain.DTO
{
    public class SendMessageDTO
    {
        public int Delay { get; set; }
        public string MessageBody { get; set; }
    }
}

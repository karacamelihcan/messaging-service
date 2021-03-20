using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessagingService.API.Models.ResponseModels.Messages
{
    public class MessageView
    {
        public Guid ID { get; set; }
        public string SenderName { get; set; }
        public string ReceiverName { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }
}

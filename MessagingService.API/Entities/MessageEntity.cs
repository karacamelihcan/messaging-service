using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessagingService.API.Entities
{
    public class MessageEntity
    {
        public Guid ID { get; set; }
        public int SenderID { get; set; }
        public int ReceiverID { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }

    }
}

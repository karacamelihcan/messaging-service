using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessagingService.API.Models.RequestModels.Users
{
    public class CheckBlockedRequest
    {
        public string SenderName { get; set; }
        public string ReceiverName { get; set; }
    }
}

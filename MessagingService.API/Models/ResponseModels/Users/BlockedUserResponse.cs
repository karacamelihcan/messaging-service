using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessagingService.API.Models.ResponseModels.Users
{
    public class BlockedUserResponse
    {
        public Guid ID { get; set; }
        public string BlockedUserName { get; set; }
        public DateTime Date { get; set; }
    }
}

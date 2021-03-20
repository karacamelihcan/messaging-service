using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessagingService.API.Models.ResponseModels.Users
{
    public class TokenResponse
    {
        public string UserName { get; set; }
        public DateTime ExpireTime { get; set; }
        public string Token { get; set; }
    }
}

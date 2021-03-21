using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MessagingService.API.Models.RequestModels.Users
{
    public class GetBlockedRequest
    {
        [Required]
        public string Username { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MessagingService.API.Models.RequestModels.Users
{
    public class BlockUserRequest
    {
        [Required]
        public string KickerName { get; set; }
        [Required]
        public string BlockedName { get; set; }
    }
}

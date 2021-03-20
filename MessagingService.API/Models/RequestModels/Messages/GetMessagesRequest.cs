﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MessagingService.API.Models.RequestModels.Messages
{
    public class GetMessagesRequest
    {
        [Required]
        public string Username { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MessagingService.API.Models.RequestModels.Users
{
    public class AddUserRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

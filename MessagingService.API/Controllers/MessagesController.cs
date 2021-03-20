using MessagingService.API.Models.RequestModels.Messages;
using MessagingService.API.Services.MessageServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessagingService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _service;
        public MessagesController(IMessageService service)
        {
            _service = service;
        }



        [HttpGet(Name = nameof(GetMessagesByUserName))]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetMessagesByUserName([FromQuery] GetMessagesRequest request)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            var msg = await _service.GetMessagesByUsername(request);

            if (msg == null)
                return NotFound("There is no such username or message yet.");

            return Ok(msg);

        }
    }
}

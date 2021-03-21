using MessagingService.API.Models.RequestModels.Messages;
using MessagingService.API.Models.RequestModels.Users;
using MessagingService.API.Services.MessageServices;
using MessagingService.API.Services.UserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessagingService.API.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _service;
        private readonly IUserService _userService;
        public MessagesController(IMessageService service, IUserService userService)
        {
            _service = service;
            _userService = userService;
        }



        [HttpGet(Name = nameof(GetMessages))]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetMessages([FromQuery] string username,[FromQuery] string sendername)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            var msg = await _service.GetMessages(username,sendername);

            if (msg == null)
                return NoContent();

            return Ok(msg);

        }


        [HttpPost(Name = nameof(Send))]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Send([FromBody] SendMessageRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if ((!await _userService.isUserNameExist(request.SenderName) || (!await _userService.isUserNameExist(request.ReceiverName))))
                return NotFound("There is no such a username");

            if (await _userService.isBlocked(new BlockUserRequest { KickerName = request.ReceiverName, BlockedName = request.SenderName }))
                return BadRequest("You cannot send message to this user");

            var success = await _service.Send(request);

            if (success == 0)
                return BadRequest("An error occured");

            return Ok();
        }


    }
}

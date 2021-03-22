using MessagingService.API.Models.RequestModels.Users;
using MessagingService.API.Services.UserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessagingService.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet(Name = nameof(Get))]
        public IActionResult Get()
        {
            var users = _userService.GetUsers();
            if (users == null)
                return NoContent();
            return Ok(users);
        }

        [HttpPost(Name = nameof(Register))]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] AddUserRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            if (await _userService.isUserNameExist(request.UserName))
                return BadRequest();

            if (await _userService.AddUser(request) == 0)
                return BadRequest();

            return Ok();
        }


        [HttpPost(Name = nameof(Block))]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Block([FromBody] BlockUserRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if ((!await _userService.isUserNameExist(request.KickerName) || (! await _userService.isUserNameExist(request.BlockedName))))
                return NotFound("There is no such a username");
                
                
            var isBlocked = await _userService.isBlocked(request);

            if (isBlocked)
                return BadRequest("You have already blocked this user");

            if (await _userService.BlockUser(request) == 0)
                return NotFound("Your username or the username you want to block could not be found.");

            return Ok();
        }


        [HttpGet(Name =nameof(GetBlockedRequest))]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetBlockedUser([FromQuery] GetBlockedRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!await _userService.isUserNameExist(request.Username))
                return NotFound("There is no such a username");


            var result = await _userService.GetBlockedsByUserName(request);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}

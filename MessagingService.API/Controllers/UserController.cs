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
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet(Name = nameof(GetUsers))]
        public IActionResult GetUsers()
        {
            var users = _userService.GetUsers();
            if (users == null)
                return NoContent();
            return Ok(users);
        }

        [HttpPost(Name = nameof(Add))]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [AllowAnonymous]
        public async Task<IActionResult> Add([FromBody] AddUserRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            if (await _userService.isUserNameExist(request))
                return BadRequest();

            if (await _userService.AddUser(request) == 0)
                return BadRequest();

            return Ok();
        }
    }
}

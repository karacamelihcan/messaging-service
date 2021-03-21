using MessagingService.API.Models.RequestModels.Users;
using MessagingService.API.Services.UserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessagingService.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserService _service;
        public AuthController(IUserService service)
        {
            _service = service;
        }

        [HttpPost(Name =nameof(Login))]
        [ProducesResponseType(200)] //OK
        [ProducesResponseType(400)] //Unauthorized
        [ProducesResponseType(401)] //BadRequest
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var result = await _service.Login(request);

            if (result == null)
                return Unauthorized();

            return Ok(result);

        }
    }
}

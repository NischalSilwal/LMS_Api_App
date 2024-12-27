using LMS_Api_App.Application.DTOs.Admin;
using LMS_Api_App.Application.Features.Admin.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LMS_Api_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserDto loginDto)
        {
            var token = await _mediator.Send(new LoginCommand(loginDto));
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }

        [HttpPost("Signup")]

        public async Task<IActionResult> Signup([FromBody] UserRegisterDto userRegisterDto)
        {
            var signup = await _mediator.Send(new RegisterUserCommand(userRegisterDto));

           return Ok(signup);
        }
    }
}

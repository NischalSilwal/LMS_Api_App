using LMS_Api_App.Application.DTOs.Admin;
using LMS_Api_App.Application.Interfaces;
using LMS_Api_App.Application.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_Api_App.Application.Features.Admin.Command
{
    public class LoginCommand : IRequest<string>
    {
        public UserDto loginDto { get; }

        public LoginCommand(UserDto userDto)
        {
            loginDto = userDto;
        }
    }
    public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly IUserService _userService;
        private readonly IJwtTokenHelper _jwtTokenHelper;
        public LoginCommandHandler(IUserService userService, IJwtTokenHelper jwtTokenHelper)
        {
            _userService = userService;
            _jwtTokenHelper = jwtTokenHelper;
        }
        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.Authenticate(request.loginDto.Username, request.loginDto.Password);
            if (user == null)
            {
                return null; // Unauthorized
            }

            return _jwtTokenHelper.GenerateToken(user);
        }
    }
}

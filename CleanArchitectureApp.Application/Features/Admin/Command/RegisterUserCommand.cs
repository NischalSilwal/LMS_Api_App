using LMS_Api_App.Application.DTOs.Admin;
using LMS_Api_App.Application.Interfaces.Services;
using LMS_Api_App.Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LMS_Api_App.Application.Features.Admin.Command
{
    public class RegisterUserCommand : IRequest<bool>
    {
        public UserRegisterDto _userRegisterDto { get; }

        public RegisterUserCommand(UserRegisterDto userRegisterDto)
        {
            _userRegisterDto = userRegisterDto;
        }
    }
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, bool>
    {
        private readonly IUserService _userService;

        public RegisterUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            // Hash the password
            string hashPassword;
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(request._userRegisterDto.Password));
                hashPassword = BitConverter.ToString(hashBytes).Replace("-", "");
            }

            // Create the user entity
            var user = new Users
            {
                Username = request._userRegisterDto.Username,
                Password = hashPassword,
                Email = request._userRegisterDto.Email
            };

            // Call the service to register the user
            await _userService.RegisterUserAsync(user);

            // Return true if registration was successful
            return true;
        }
    }
}

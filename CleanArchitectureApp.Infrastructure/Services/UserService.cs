using LMS_Api_App.Application.Interfaces.Repositories.User;
using LMS_Api_App.Domain.Model;

namespace LMS_Api_App.Application.Interfaces.Services
{
    public class UserService : IUserService
    {
        public readonly IUserRepository _UserRepository;
        public UserService(IUserRepository userRepository)
        {
            _UserRepository = userRepository;
        }
        public async Task<Users> Authenticate(string username, string password)
        {
            return await _UserRepository.Authenticate(username, password);
        }

        public async Task RegisterUserAsync(Users user)
        {
            await _UserRepository.RegisterUserAsync(user);

        }
    }
}

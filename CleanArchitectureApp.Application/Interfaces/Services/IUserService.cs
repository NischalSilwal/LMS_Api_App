using LMS_Api_App.Domain.Model;

namespace LMS_Api_App.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<Users> Authenticate(string username, string password);
        Task RegisterUserAsync(Users user);

    }
}

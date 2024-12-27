using LMS_Api_App.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_Api_App.Application.Interfaces.Repositories.User
{
    public interface IUserRepository
    {
        Task<Users> Authenticate(string username, string password);
        Task RegisterUserAsync(Users user);
    }
}

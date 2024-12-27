using LMS_Api_App.Application.Interfaces.Repositories.User;
using LMS_Api_App.Domain.Model;
using LMS_Api_App.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace LMS_Api_App.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        public async Task<Users> Authenticate(string username, string password)
        {
            
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                string hashString = BitConverter.ToString(hashBytes).Replace("-", "");
                return await _context.Users.FirstOrDefaultAsync(u => u.Username == username && u.Password == hashString);
            }

            
        }

        public async Task RegisterUserAsync(Users user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}

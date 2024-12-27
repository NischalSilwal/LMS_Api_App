using LMS_Api_App.Domain.Model;

namespace LMS_Api_App.Application.Interfaces.Services
{
    public interface IStudentService
    {
        Task<int> AddStudentAsync(Student student);
        Task<Student> GetStudentByIdAsync(int id);
        Task<IEnumerable<Student>> GetAllStudentAsync();
        Task<bool> UpdateStudentAsync(Student student);
        Task<bool> DeleteStudentAsync(int id);
    }
}

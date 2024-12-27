using LMS_Api_App.Domain.Model;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using LMS_Api_App.Application.Interfaces.Repositories;


public class StudentRepository : IStudentRepository
{
    private readonly string _connectionString;

    public StudentRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<int> AddStudentAsync(Student student)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var result = await connection.QuerySingleAsync<int>("sp_Student_CRUD", new
            {
                Flag = "INSERT",
                Name = student.Name,
                Email = student.Email,
                ContactNumber = student.ContactNumber,
                Department = student.Department
            }, commandType: CommandType.StoredProcedure);

            return result; // Return the newly inserted StudentId
        }
    }

    public async Task<Student> GetStudentByIdAsync(int id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var student = await connection.QueryFirstOrDefaultAsync<Student>("sp_Student_CRUD", new
            {
                Flag = "GET_BY_ID",
                StudentId = id
            }, commandType: CommandType.StoredProcedure);

            if (student == null)
                throw new KeyNotFoundException($"Student with ID {id} was not found.");

            return student;
        }
    }

    public async Task<IEnumerable<Student>> GetAllStudentAsync()
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var students = await connection.QueryAsync<Student>("sp_Student_CRUD", new
            {
                Flag = "GET"
            }, commandType: CommandType.StoredProcedure);

            return students; // Returns a list of all students
        }
    }

    public async Task<bool> UpdateStudentAsync(Student student)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var result = await connection.ExecuteAsync("sp_Student_CRUD", new
            {
                Flag = "UPDATE",
                StudentId = student.StudentId,
                Name = student.Name,
                Email = student.Email,
                ContactNumber = student.ContactNumber,
                Department = student.Department
            }, commandType: CommandType.StoredProcedure);

            //return result > 0; // Returns true if rows are affected (Need to fix it is giving -1 (false if when data is updated in database)
            return true;
        }
    }

    public async Task<bool> DeleteStudentAsync(int id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var result = await connection.ExecuteAsync("sp_Student_CRUD", new
            {
                Flag = "DELETE",
                StudentId = id
            }, commandType: CommandType.StoredProcedure);

            return result > 0; // Returns true if the student was successfully deleted
        }
    }
}

using LMS_Api_App.Application.DTOs.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_Api_App.Application.Mappers
{
    public static class StudentMapper
    {
        public static IEnumerable<StudentDto> ToDto(IEnumerable<Domain.Model.Student> students)
        {
            return students.Select(student => new StudentDto
            {
                StudentId = student.StudentId,
                Name = student.Name,
                Email = student.Email,
                ContactNumber = student.ContactNumber,
                Department = student.Department
            });
        }
    }

}

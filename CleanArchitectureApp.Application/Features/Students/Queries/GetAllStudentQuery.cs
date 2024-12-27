using LMS_Api_App.Application.DTOs.Student;
using LMS_Api_App.Application.Interfaces.Services;
using LMS_Api_App.Application.Mappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_Api_App.Application.Features.Student.Queries
{
    public class GetAllStudentQuery : IRequest<IEnumerable<StudentDto>> { }

    public class GetAllStudentQueryHandler : IRequestHandler<GetAllStudentQuery, IEnumerable<StudentDto>>
    {
        private readonly IStudentService _studentService;
        public GetAllStudentQueryHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<IEnumerable<StudentDto>> Handle(GetAllStudentQuery request, CancellationToken cancellationToken)
        {
            // Fetch all students from the service
            var students = await _studentService.GetAllStudentAsync();

            // Map domain model to DTO
            return StudentMapper.ToDto(students);
        }
    }
}

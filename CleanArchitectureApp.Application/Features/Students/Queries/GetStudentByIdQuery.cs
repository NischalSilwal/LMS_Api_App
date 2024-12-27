using LMS_Api_App.Application.DTOs.Student;
using LMS_Api_App.Application.Interfaces.Repositories;
using LMS_Api_App.Application.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_Api_App.Application.Features.Student.Queries
{
    public class GetStudentByIdQuery : IRequest<StudentDto>
    {
        public required int Id { get; set; }
    }
    public class GetStudentByIdHandler : IRequestHandler<GetStudentByIdQuery, StudentDto>
    {
        private readonly IStudentService _service;

        public GetStudentByIdHandler(IStudentService service)
        {
            _service = service;
        }

        public async Task<StudentDto> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _service.GetStudentByIdAsync(request.Id);

            return new StudentDto
            {
                StudentId = student.StudentId,
                Name = student.Name,
                Email = student.Email,
                ContactNumber = student.ContactNumber,
                Department = student.Department
            };
        }
    }
}

using LMS_Api_App.Application.DTOs.Student;
using LMS_Api_App.Application.Interfaces.Services;
using MediatR;

namespace LMS_Api_App.Application.Features.Student.Command
{
    public class UpdateStudentCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public StudentDto StudentDto { get; set; }

        public UpdateStudentCommand(int id, StudentDto studentDto)
        {
            Id = id;
            StudentDto = studentDto;
        }
    }

    public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, bool>
    {
        private readonly IStudentService _service;

        public UpdateStudentHandler(IStudentService service)
        {
            _service = service;
        }

        public async Task<bool> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {

            var existingStudent = await _service.GetStudentByIdAsync(request.Id);
            if (existingStudent == null)
            {
                return false; // Student not found
            }

            // Merge provided values with existing values
            var updatedStudent = new Domain.Model.Student
            {
                StudentId = existingStudent.StudentId,
                Name = request.StudentDto.Name,
                Email = request.StudentDto.Email,
                ContactNumber =  request.StudentDto.ContactNumber,
                Department =request.StudentDto.Department
            };

            var result = await _service.UpdateStudentAsync(updatedStudent);
            return result; // Returns the result of the update operation
        }
    }
}

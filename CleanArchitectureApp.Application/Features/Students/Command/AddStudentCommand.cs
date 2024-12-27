using LMS_Api_App.Application.DTOs.Student;
using LMS_Api_App.Application.Features.Student.Queries;
using LMS_Api_App.Application.Interfaces.Services;
using LMS_Api_App.Domain.Model;
using MediatR;

namespace LMS_Api_App.Application.Features.Student.Command
{
    public class AddStudentCommand : IRequest<int>
    {
        public AddStudentDto AddStudentDto { get; set; }
        public AddStudentCommand(AddStudentDto addStudentDto)
        {
            AddStudentDto = addStudentDto;
        }
       
    }

    public class AddStudentCommandHandler : IRequestHandler<AddStudentCommand, int>
    {
        private readonly IStudentService _studentService;
        public AddStudentCommandHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<int> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var student = new LMS_Api_App.Domain.Model.Student
            {
                Name = request.AddStudentDto.Name,
                Email = request.AddStudentDto.Email,
                ContactNumber = request.AddStudentDto.ContactNumber,
                Department = request.AddStudentDto.Department,
            };
            var response = await _studentService.AddStudentAsync(student);
            return response;
        }
    }
}

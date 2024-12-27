using LMS_Api_App.Application.DTOs;
using LMS_Api_App.Application.DTOs.Student;
using LMS_Api_App.Application.Features.Student.Command;
using LMS_Api_App.Application.Features.Student.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS_Api_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([FromForm] AddStudentDto addStudentDto)
        {
            var studentId = await _mediator.Send(new AddStudentCommand(addStudentDto));
            return Ok(studentId); // Return created product Id
        }

        [HttpGet]
        public async Task<IActionResult> GetStudentList([FromQuery] GetAllStudentQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var result = await _mediator.Send(new GetStudentByIdQuery { Id = id });

            if (result == null)
                return NotFound($"Student with ID {id} not found.");

            return Ok(result);
        }

        // Update Student Endpoint
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] StudentDto studentDto)
        {
            if (studentDto == null)
            {
                return BadRequest("Student data is required.");
            }

            var command = new UpdateStudentCommand(id, studentDto);
            var result = await _mediator.Send(command);

            if (!result)
            {
                return NotFound($"Student with ID {id} not found.");
            }

            return Ok("Student updated successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var result = await _mediator.Send(new DeleteStudentCommand { Id = id });

            if (!result)
                return NotFound($"Student with ID {id} not found.");

            return NoContent();
        }
    }
}

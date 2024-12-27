using LMS_Api_App.Application.DTOs.Author;
using LMS_Api_App.Application.Features.Author.Command;
using LMS_Api_App.Application.Features.Author.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LMS_Api_App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAuthors()
        {
            var authors = await _mediator.Send(new GetAllAuthorsQuery());
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorById(int id)
        {
            var author = await _mediator.Send(new GetAuthorByIdQuery { AuthorId = id });
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> AddAuthor([FromBody] AuthorDto authorDto)
        {
            var authorId = await _mediator.Send(new AddAuthorCommand(authorDto));
            return CreatedAtAction(nameof(GetAuthorById), new { id = authorId }, authorDto);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, [FromBody] AuthorDto authorDto)
        {
            if (id != authorDto.AuthorId)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new UpdateAuthorCommand(id, authorDto));
            if (!result)
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var result = await _mediator.Send(new DeleteAuthorCommand { AuthorId = id });
            if (!result)
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return NoContent();
        }
    }
}

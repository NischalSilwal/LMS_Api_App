using LMS_Api_App.Application.DTOs.Book;
using LMS_Api_App.Application.Features.Book.Command;
using LMS_Api_App.Application.Features.Book.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LMS_Api_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetAllBooks()
        {
            var query = new GetAllBooksQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBookById(int id)
        {
            var query = new GetBookByIdQuery(id);
            var result = await _mediator.Send(query);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddBook([FromForm] AddBookCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetBookById), new { id = result }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> UpdateBook(int id, [FromBody] UpdateBookCommand command)
        {
            if (id != command.BookId) return BadRequest("Book ID mismatch.");

            var result = await _mediator.Send(command);
            return result ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteBook(int id)
        {
            var command = new DeleteBookCommand { BookId = id };
            var result = await _mediator.Send(command);
            return result ? NoContent() : NotFound();
        }
    }
}

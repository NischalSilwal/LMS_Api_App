using LMS_Api_App.Application.DTOs.Author;
using LMS_Api_App.Application.DTOs.TransactionDto;
using LMS_Api_App.Application.Features.Author.Command;
using LMS_Api_App.Application.Features.Transactions.Queries;
using LMS_Api_App.Application.Features.Transactions.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using LMS_Api_App.Application.Features.Student.Queries;
using LMS_Api_App.Application.Features.Transaction.Queries;
using LMS_Api_App.Application.DTOs.Student;
using LMS_Api_App.Application.Features.Student.Command;
using LMS_Api_App.Application.Features.Transaction.Command;

namespace LMS_Api_App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransactionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var transactions = await _mediator.Send(new GetAllTransactionsQuery());
            return Ok(transactions);
        }



        [HttpPost]
        public async Task<IActionResult> Add(AddTransactionDto addTransactionDto)
        {
            var tansactionId = await _mediator.Send(new AddTransactionCommand(addTransactionDto));
            return Ok(tansactionId);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var transaction = await _mediator.Send(new GetTransactionByIdCommand { Id = id });
            if (transaction == null)
            {
                return NotFound();
            }
            return Ok(transaction);
        }
        // Update Transaction Endpoint
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTransaction(int id, [FromBody] AddTransactionDto addTransactionDto)
        {
            if (addTransactionDto == null)
            {
                return BadRequest("Transaction data is required.");
            }

            var command = new UpdateTransactionCommand(addTransactionDto,id);
            var result = await _mediator.Send(command);

            if (!result)
            {
                return NotFound($"Transaction with ID {id} not found.");
            }

            return Ok("Transaction updated successfully.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            var result = await _mediator.Send(new DeleteTransactionCommand { Id = id });

            if (!result)
                return NotFound($"Transaction with ID {id} not found.");

            return NoContent();
        }



    }
}

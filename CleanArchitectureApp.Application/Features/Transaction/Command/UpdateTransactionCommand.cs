using LMS_Api_App.Application.DTOs.TransactionDto;
using LMS_Api_App.Application.Interfaces.Repositories.TransactionRepository;
using LMS_Api_App.Application.Interfaces.Services;
using LMS_Api_App.Domain.Model;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LMS_Api_App.Application.Features.Transaction.Command
{
    public class UpdateTransactionCommand : IRequest<bool>
    {
        public AddTransactionDto AddTransaction { get; set; }
        public int Id { get; set; }

        public UpdateTransactionCommand(AddTransactionDto addTransactionDto, int id)
        {
            AddTransaction = addTransactionDto;
            Id = id;
        }
    }

    public class UpdateTransactionCommandHandler : IRequestHandler<UpdateTransactionCommand, bool>
    {
        private readonly ITransactionService _service;

        public UpdateTransactionCommandHandler(ITransactionService service)
        {
            _service = service;
        }

        public async Task<bool> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
        {
            // Make sure the method GetTransactionByIdAsync returns a Task<Transactions> and await it
            var existingTransaction = await _service.GetTransactionByIdAsync(request.Id);

            // If the transaction doesn't exist, return false
            if (existingTransaction == null)
            {
                return false;
            }

            // Create a new transaction based on the provided details
            var updateTransaction = new Domain.Model.Transactions
            {
                TransactionId = existingTransaction.TransactionId,
                StudentId = existingTransaction.StudentId, // Assuming you want the StudentId from the existing transaction
                BookId = request.AddTransaction.BookId,
                UserId = request.AddTransaction.UserId,
                TransactionType = request.AddTransaction.TransactionType,
                Date = request.AddTransaction.Date
            };

            // Call the update method and return the result
            var result = await _service.UpdateTransactionAsync(updateTransaction);
            return result;
        }
    }
}

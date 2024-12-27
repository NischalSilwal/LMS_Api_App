using LMS_Api_App.Application.DTOs.TransactionDto;
using LMS_Api_App.Application.Interfaces.Repositories.TransactionRepository;
using LMS_Api_App.Application.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_Api_App.Application.Features.Transactions.Command
{
    public class AddTransactionCommand : IRequest<int>
    {
        public AddTransactionDto AddTransactionDto { get; }

        public AddTransactionCommand(AddTransactionDto addTransactionDto)
        {
            AddTransactionDto = addTransactionDto;
        }
    }
    public class AddTransactionCommandHandler : IRequestHandler<AddTransactionCommand, int>
    {
        private readonly ITransactionService _service;

        public AddTransactionCommandHandler(ITransactionService service)
        {
            _service = service;
        }

        public async Task<int> Handle(AddTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = new LMS_Api_App.Domain.Model.Transactions
            {
                // Map properties from AddTransactionDto to the entity
                StudentId = request.AddTransactionDto.StudentId,
                BookId = request.AddTransactionDto.BookId,
                UserId = request.AddTransactionDto.UserId,
                TransactionType = request.AddTransactionDto.TransactionType,
                Date = request.AddTransactionDto.Date
            };

            await _service.AddTransactionAsync(transaction);
            return transaction.TransactionId; // Return the newly created transaction ID
        }
    }



}

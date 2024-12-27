using LMS_Api_App.Application.DTOs.TransactionDto;
using LMS_Api_App.Application.Interfaces.Repositories.TransactionRepository;
using LMS_Api_App.Application.Interfaces.Services;
using LMS_Api_App.Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_Api_App.Application.Features.Transaction.Queries
{
    public class GetTransactionByIdCommand : IRequest<AddTransactionDto>
    {
        public required int Id { get; set; }
    }
    public class GetTransactionByIdCommandHandler : IRequestHandler<GetTransactionByIdCommand, AddTransactionDto>
    {
        private readonly ITransactionService _service;

        public GetTransactionByIdCommandHandler(ITransactionService service)
        {
            _service = service;
        }
        public async Task<AddTransactionDto> Handle(GetTransactionByIdCommand request, CancellationToken cancellationToken)
        {
            var transaction = await _service.GetTransactionByIdAsync(request.Id);
            return new AddTransactionDto
            {
                StudentId = transaction.StudentId,
                UserId = transaction.UserId,
                BookId = transaction.BookId,
                TransactionType = transaction.TransactionType,
                Date = transaction.Date,
            };
        }
    }
}

using LMS_Api_App.Application.Features.Student.Command;
using LMS_Api_App.Application.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_Api_App.Application.Features.Transaction.Command
{
    public class DeleteTransactionCommand : IRequest<bool>
    {
        public required int Id { get; set; }
    }

    public class DeleteTransactionCommandHandler : IRequestHandler<DeleteTransactionCommand, bool>
    {
        private readonly ITransactionService _service;

        public DeleteTransactionCommandHandler(ITransactionService service)
        {
            _service = service;
        }
        public async Task<bool> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
        {
            return await _service.DeleteTransactionAsync(request.Id);
        }
    }
}

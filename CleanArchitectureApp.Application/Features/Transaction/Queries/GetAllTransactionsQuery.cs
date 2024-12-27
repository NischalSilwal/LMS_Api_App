using LMS_Api_App.Application.Interfaces.Repositories.TransactionRepository;
using LMS_Api_App.Application.Interfaces.Services;
using MediatR;

namespace LMS_Api_App.Application.Features.Transactions.Queries
{
    public class GetAllTransactionsQuery : IRequest<IEnumerable<LMS_Api_App.Domain.Model.Transactions>>
    {
    }
    public class GetAllTransactionsQueryHandler : IRequestHandler<GetAllTransactionsQuery, IEnumerable<LMS_Api_App.Domain.Model.Transactions>>
    {
        private readonly ITransactionService _service;

        public GetAllTransactionsQueryHandler(ITransactionService service)
        {
            _service = service;
        }

        public async Task<IEnumerable<LMS_Api_App.Domain.Model.Transactions>> Handle(GetAllTransactionsQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetAllTransactionsAsync();
        }

       
    }

}

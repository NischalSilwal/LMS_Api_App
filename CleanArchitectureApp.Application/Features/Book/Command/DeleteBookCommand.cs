using LMS_Api_App.Application.Interfaces.Repositories;
using LMS_Api_App.Application.Interfaces.Repositories.Book;
using LMS_Api_App.Application.Interfaces.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LMS_Api_App.Application.Features.Book.Command
{
    // Ensure DeleteBookCommand implements IRequest<Unit>
    public class DeleteBookCommand : IRequest<bool>
    {
        public int BookId { get; set; }
    }

    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, bool>
    {
        private readonly IBookRepository _bookRepository;

        public DeleteBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            return await _bookRepository.DeleteBookAsync(request.BookId);
        }
    }
}

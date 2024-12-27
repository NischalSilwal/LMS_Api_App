using LMS_Api_App.Application.DTOs.Book;
using LMS_Api_App.Application.Interfaces.Repositories;
using LMS_Api_App.Application.Interfaces.Repositories.Book;
using LMS_Api_App.Application.Interfaces.Services;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LMS_Api_App.Application.Features.Book.Command
{
    // Change IRequest<Unit> to IRequest<bool>
    public class UpdateBookCommand : IRequest<bool>
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string ISBN { get; set; }
        public int Quantity { get; set; }
        public List<int>? AuthorIds { get; set; }
    }

    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, bool>
    {
        private readonly IBookRepository _bookRepository;

        public UpdateBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<bool> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new LMS_Api_App.Domain.Model.Book
            {
                BookId = request.BookId,
                Title = request.Title,
                Genre = request.Genre,
                ISBN = request.ISBN,
                Quantity = request.Quantity
            };

            return await _bookRepository.UpdateBookAsync(book, request.AuthorIds);
        }
    }
}

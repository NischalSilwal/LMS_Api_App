
using LMS_Api_App.Application.Interfaces.Repositories;
using LMS_Api_App.Application.Interfaces.Repositories.Book;
using LMS_Api_App.Application.Interfaces.Services;
using LMS_Api_App.Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_Api_App.Application.Features.Book.Command
{
    public class AddBookCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public string ISBN { get; set; }
        public int Quantity { get; set; }
        public List<int> AuthorIds { get; set; }
    }
    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, int>
    {
        private readonly IBookRepository _bookRepository;

        public AddBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<int> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            var book = new LMS_Api_App.Domain.Model.Book
            {
                Title = request.Title,
               // AuthorId = request.AuthorIds
                Genre = request.Genre,
                ISBN = request.ISBN,
                Quantity = request.Quantity
            };

            return await _bookRepository.AddBookAsync(book, request.AuthorIds);
        }
    }
}

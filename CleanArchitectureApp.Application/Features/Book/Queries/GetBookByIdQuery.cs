using LMS_Api_App.Application.DTOs.Book;
using LMS_Api_App.Application.Interfaces.Repositories.Book;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_Api_App.Application.Features.Book.Queries
{
    public class GetBookByIdQuery : IRequest<BookDto>
    {
        public int BookId { get; set; }
        public GetBookByIdQuery(int bookId)
        {
            BookId = bookId;
        }
    }

    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookDto>
    {
        private readonly IBookRepository _bookRepository;

        public GetBookByIdQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<BookDto> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            return await _bookRepository.GetBookByIdAsync(request.BookId);
        }
    }
}

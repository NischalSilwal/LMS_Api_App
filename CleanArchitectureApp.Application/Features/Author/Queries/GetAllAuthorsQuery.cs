using LMS_Api_App.Application.DTOs.Author;
using LMS_Api_App.Application.Interfaces.Repositories.Author;
using LMS_Api_App.Application.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_Api_App.Application.Features.Author.Queries
{
    public class GetAllAuthorsQuery : IRequest<IEnumerable<AuthorDto>> { }

    public class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQuery, IEnumerable<AuthorDto>>
    {
        private readonly IAuthorService _authorService;

        public GetAllAuthorsQueryHandler(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public async Task<IEnumerable<AuthorDto>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            return await _authorService.GetAllAuthorsAsync();
        }
    }
}

using LMS_Api_App.Application.DTOs.Author;
using LMS_Api_App.Application.Interfaces.Repositories.Author;
using LMS_Api_App.Application.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_Api_App.Application.Features.Author.Command
{
    public class AddAuthorCommand : IRequest<int>
    {
        public AuthorDto AuthorDto { get; set; }
        public AddAuthorCommand(AuthorDto authorDto)
        {
            AuthorDto = authorDto;
        }
    }
    public class AddAuthorCommandHandler : IRequestHandler<AddAuthorCommand, int>
    {
        private readonly IAuthorService _authorService;

        public AddAuthorCommandHandler(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public async Task<int> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
        {
            return await _authorService.AddAuthorAsync(request.AuthorDto);
        }
    }
}

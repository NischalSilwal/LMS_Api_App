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
    public class UpdateAuthorCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public AuthorDto AuthorDto { get; set; }

        public UpdateAuthorCommand(int id, AuthorDto authorDto)
        {
            Id = id;
            AuthorDto = authorDto;
        }
    }
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, bool>
    {
        private readonly IAuthorService _authorService;

        public UpdateAuthorCommandHandler(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public async Task<bool> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            await _authorService.UpdateAuthorAsync(request.AuthorDto);
            return true;
        }
    }
}

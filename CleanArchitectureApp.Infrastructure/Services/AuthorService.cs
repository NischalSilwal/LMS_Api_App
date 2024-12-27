using LMS_Api_App.Application.DTOs.Author;
using LMS_Api_App.Application.Interfaces.Repositories.Author;
using LMS_Api_App.Application.Interfaces.Services;


namespace LMS_Api_App.Infrastructure.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authRepository;
        public AuthorService(IAuthorRepository authorRepository)
        {
            _authRepository = authorRepository;
        }
        public async Task<int> AddAuthorAsync(AuthorDto authorDto)
        {
            return await _authRepository.AddAuthorAsync(authorDto);
        }

        public async Task DeleteAuthorAsync(int authorId)
        {
            await _authRepository.DeleteAuthorAsync(authorId);
        }

        public async Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync()
        {
            return await _authRepository.GetAllAuthorsAsync();
        }

        public Task<AuthorDto> GetAuthorByIdAsync(int authorId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAuthorAsync(AuthorDto authorDto)
        {
            throw new NotImplementedException();
        }
    }
}

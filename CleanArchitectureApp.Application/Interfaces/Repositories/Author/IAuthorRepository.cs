using LMS_Api_App.Application.DTOs.Author;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_Api_App.Application.Interfaces.Repositories.Author
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync();
        Task<AuthorDto> GetAuthorByIdAsync(int authorId);
        Task<int> AddAuthorAsync(AuthorDto authorDto);
        Task UpdateAuthorAsync(AuthorDto authorDto);
        Task DeleteAuthorAsync(int authorId);
    }

}

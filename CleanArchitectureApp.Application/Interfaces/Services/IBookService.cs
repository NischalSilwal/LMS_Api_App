
using LMS_Api_App.Application.DTOs.Book;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS_Api_App.Application.Interfaces.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetAllBooksAsync();
        Task<BookDto> GetBookByIdAsync(int bookId);
        Task<int> AddBookAsync(LMS_Api_App.Domain.Model.Book book, List<int> authorIds);
        Task<bool> UpdateBookAsync(LMS_Api_App.Domain.Model.Book book, List<int> authorIds);
        Task<bool> DeleteBookAsync(int bookId);
    }
}

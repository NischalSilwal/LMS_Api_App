using LMS_Api_App.Application.DTOs.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_Api_App.Application.Interfaces.Repositories.Book
{
    public interface IBookRepository
    {
        Task<IEnumerable<BookDto>> GetAllBooksAsync();
        Task<BookDto> GetBookByIdAsync(int bookId);
        Task<int> AddBookAsync(LMS_Api_App.Domain.Model.Book book, List<int> authorIds);
        Task<bool> UpdateBookAsync(LMS_Api_App.Domain.Model.Book book, List<int> authorIds);
        Task<bool> DeleteBookAsync(int bookId);
    }

}

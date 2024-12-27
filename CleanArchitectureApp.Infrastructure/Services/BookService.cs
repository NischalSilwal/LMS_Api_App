using LMS_Api_App.Application.DTOs.Book;
using LMS_Api_App.Application.Interfaces.Repositories.Book;
using LMS_Api_App.Application.Interfaces.Services;
using LMS_Api_App.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS_Api_App.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<BookDto>> GetAllBooksAsync()
        {
            // Fetch all books from the repository
            return await _bookRepository.GetAllBooksAsync();
        }

        public async Task<BookDto> GetBookByIdAsync(int bookId)
        {
            // Fetch a single book by ID from the repository
            return await _bookRepository.GetBookByIdAsync(bookId);
        }

        public async Task<int> AddBookAsync(LMS_Api_App.Domain.Model.Book book, List<int> authorIds)
        {
            // Add a new book using the repository and return the book ID
            return await _bookRepository.AddBookAsync(book, authorIds);
        }

        public async Task<bool> UpdateBookAsync(LMS_Api_App.Domain.Model.Book book, List<int> authorIds)
        {
            // Update an existing book in the repository and return a success flag
            return await _bookRepository.UpdateBookAsync(book, authorIds);
        }

        public async Task<bool> DeleteBookAsync(int bookId)
        {
            // Delete a book using the repository and return a success flag
            return await _bookRepository.DeleteBookAsync(bookId);
        }
    }
}

using Dapper;
using LMS_Api_App.Application.DTOs.Author;
using LMS_Api_App.Application.DTOs.Book;
using LMS_Api_App.Application.Interfaces.Repositories.Book;
using LMS_Api_App.Domain.Model;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace LMS_Api_App.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly string _connectionString;

        public BookRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<BookDto>> GetAllBooksAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var books = await connection.QueryAsync<BookDto, string, BookDto>(
                    "ManageBooks",
                    (book, authors) =>
                    {
                        // Initialize the Authors list
                        book.Authors = new List<AuthorDto>();

                        if (!string.IsNullOrEmpty(authors))
                        {
                            // Split authors into AuthorId:AuthorName pairs
                            foreach (var author in authors.Split(','))
                            {
                                var authorParts = author.Split(':');

                                // Ensure we have both AuthorId and Name
                                if (authorParts.Length == 2)
                                {
                                    if (int.TryParse(authorParts[0], out var authorId))
                                    {
                                        book.Authors.Add(new AuthorDto
                                        {
                                            AuthorId = authorId,
                                            Name = authorParts[1]
                                        });
                                    }
                                }
                            }
                        }

                        return book;
                    },
                    param: new { ActionFlag = "GET_ALL" },
                    commandType: CommandType.StoredProcedure,
                    splitOn: "Authors" // Split on the Authors column which contains the concatenated string
                );

                return books;
            }
        }

        public async Task<BookDto> GetBookByIdAsync(int bookId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ActionFlag", "GET_BY_ID");
                parameters.Add("@BookId", bookId);

                // Execute the query and retrieve the book and concatenated authors
                var bookWithAuthors = await connection.QueryAsync<BookDto, string, BookDto>(
                    "ManageBooks",
                    (book, authors) =>
                    {
                        // Initialize the authors list
                        book.Authors = new List<AuthorDto>();

                        if (!string.IsNullOrEmpty(authors))
                        {
                            // Split the authors string and map it to AuthorDto
                            foreach (var author in authors.Split(','))
                            {
                                var authorParts = author.Split(':');

                                // Ensure we have both AuthorId and Name
                                if (authorParts.Length == 2)
                                {
                                    if (int.TryParse(authorParts[0], out var authorId))
                                    {
                                        book.Authors.Add(new AuthorDto
                                        {
                                            AuthorId = authorId,
                                            Name = authorParts[1]
                                        });
                                    }
                                }
                            }
                        }

                        return book;
                    },
                    param: parameters,
                    commandType: CommandType.StoredProcedure,
                    splitOn: "Authors" // Tells Dapper where to split the result set
                );

                return bookWithAuthors.FirstOrDefault(); // Return the first result
            }
        }


        public async Task<int> AddBookAsync(Book book, List<int> authorIds)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ActionFlag", "ADD");
                parameters.Add("@Title", book.Title);
                parameters.Add("@Genre", book.Genre);
                parameters.Add("@ISBN", book.ISBN);
                parameters.Add("@Quantity", book.Quantity);
                parameters.Add("@AuthorIds", string.Join(",", authorIds));

                return await connection.ExecuteScalarAsync<int>(
                    "ManageBooks",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<bool> UpdateBookAsync(Book book, List<int> authorIds)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ActionFlag", "UPDATE");
                parameters.Add("@BookId", book.BookId);
                parameters.Add("@Title", book.Title);
                parameters.Add("@Genre", book.Genre);
                parameters.Add("@ISBN", book.ISBN);
                parameters.Add("@Quantity", book.Quantity);

                // Modify stored procedure to accept comma-separated string for AuthorIds
                parameters.Add("@AuthorIds", string.Join(",", authorIds));

                var rowsAffected = await connection.ExecuteAsync(
                  "ManageBooks",
                  parameters,
                  commandType: CommandType.StoredProcedure);

                return rowsAffected > 0;
            }
        }

        public async Task<bool> DeleteBookAsync(int bookId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ActionFlag", "DELETE");
                parameters.Add("@BookId", bookId);

                var rowsAffected = await connection.ExecuteAsync(
                    "ManageBooks",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return rowsAffected > 0;
            }
        }
    }
}

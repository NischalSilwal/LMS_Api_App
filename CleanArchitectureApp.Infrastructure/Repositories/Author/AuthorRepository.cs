using Dapper;
using LMS_Api_App.Application.DTOs.Author;
using LMS_Api_App.Application.Interfaces.Repositories.Author;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

public class AuthorRepository : IAuthorRepository
{
    private readonly string _connectionString;

    public AuthorRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync()
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var authors = await connection.QueryAsync<AuthorDto, int?, AuthorDto>(
                "ManageAuthors",
                (author, bookId) =>
                {
                    author.BookIds = author.BookIds ?? new List<int>();
                    if (bookId.HasValue)
                    {
                        author.BookIds.Add(bookId.Value);
                    }
                    return author;
                },
                splitOn: "BookId",  // Ensure splitOn matches the column name
                param: new { ActionFlag = "GET_ALL" },
                commandType: CommandType.StoredProcedure);

            return authors.GroupBy(a => a.AuthorId).Select(g =>
            {
                var groupedAuthor = g.First();
                groupedAuthor.BookIds = g.Select(a => a.BookIds.Single()).ToList();
                return groupedAuthor;
            });
        }
    }

    public async Task<AuthorDto> GetAuthorByIdAsync(int authorId)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var author = await connection.QueryAsync<AuthorDto, int?, AuthorDto>(
                "ManageAuthors",
                (author, bookId) =>
                {
                    author.BookIds = author.BookIds ?? new List<int>();
                    if (bookId.HasValue)
                    {
                        author.BookIds.Add(bookId.Value);
                    }
                    return author;
                },
                splitOn: "BookId",  // Ensure splitOn matches the column name
                param: new { ActionFlag = "GET_BY_ID", AuthorId = authorId },
                commandType: CommandType.StoredProcedure);

            var groupedAuthor = author.GroupBy(a => a.AuthorId).Select(g =>
            {
                var result = g.First();
                result.BookIds = g.Select(a => a.BookIds.Single()).ToList();
                return result;
            }).FirstOrDefault();

            return groupedAuthor;
        }
    }

    public async Task<int> AddAuthorAsync(AuthorDto authorDto)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var bookIds = string.Join(",", authorDto.BookIds);
            var authorId = await connection.ExecuteScalarAsync<int>(
                "ManageAuthors",
                new
                {
                    ActionFlag = "ADD",
                    Name = authorDto.Name,
                    Bio = authorDto.Bio,
                    BookIds = bookIds
                },
                commandType: CommandType.StoredProcedure);

            return authorId;
        }
    }

    public async Task UpdateAuthorAsync(AuthorDto authorDto)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var bookIds = string.Join(",", authorDto.BookIds);
            await connection.ExecuteAsync(
                "ManageAuthors",
                new
                {
                    ActionFlag = "UPDATE",
                    AuthorId = authorDto.AuthorId,
                    Name = authorDto.Name,
                    Bio = authorDto.Bio,
                    BookIds = bookIds
                },
                commandType: CommandType.StoredProcedure);
        }
    }

    public async Task DeleteAuthorAsync(int authorId)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.ExecuteAsync(
                "ManageAuthors",
                new { ActionFlag = "DELETE", AuthorId = authorId },
                commandType: CommandType.StoredProcedure);
        }
    }
}
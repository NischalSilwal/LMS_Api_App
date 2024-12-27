using Dapper;
using LMS_Api_App.Application.DTOs.TransactionDto;
using LMS_Api_App.Application.Interfaces.Repositories.TransactionRepository;
using LMS_Api_App.Domain.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_Api_App.Infrastructure.Repositories.TransactionRepository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly IDbConnection _dbConnection;

        public TransactionRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task AddTransactionAsync(Transactions dto)
        {
            await _dbConnection.ExecuteAsync(
"ManageTransaction",
new
{
    Action = "Add",
    dto.StudentId,
    dto.UserId,
    dto.BookId,
    dto.TransactionType,
    dto.Date
},
commandType: CommandType.StoredProcedure);
        }

        public async Task<bool> UpdateTransactionAsync(Transactions transactions)
        {

            var result = await _dbConnection.ExecuteAsync(
                "ManageTransaction",
                new
                {
                    Action = "Update",
                    TransactionId = transactions.TransactionId,
                    StudentId= transactions.StudentId,
                    UserId = transactions.UserId,
                    BookId=transactions.BookId,
                    TransactionType = transactions.TransactionType,
                    Date = transactions.Date
                },
                commandType: CommandType.StoredProcedure);
            return true;
                //result > 0;
        }

        public async Task<IEnumerable<Transactions>> GetAllTransactionsAsync()
        {
            return await _dbConnection.QueryAsync<Transactions>(
                "ManageTransaction",
                new { Action = "GetAll" },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<Transactions> GetTransactionByIdAsync(int transactionId)
        {
            return await _dbConnection.QueryFirstOrDefaultAsync<Transactions>(
                "ManageTransaction",
                new { Action = "GetById", TransactionId = transactionId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<bool> DeleteTransactionAsync(int transactionId)
        {
            var result = await _dbConnection.ExecuteAsync(
                "ManageTransaction",
                new { Action = "Delete", TransactionId = transactionId },
                commandType: CommandType.StoredProcedure);
            return result > 0;

        }
    }

}


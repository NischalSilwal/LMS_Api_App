using LMS_Api_App.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_Api_App.Application.Interfaces.Services
{
    public interface ITransactionService
    {
        Task AddTransactionAsync(Transactions transactions);
        Task<bool> UpdateTransactionAsync(Transactions transactions);
        Task<IEnumerable<Transactions>> GetAllTransactionsAsync();
        Task<Transactions> GetTransactionByIdAsync(int transactionId);
        Task<bool> DeleteTransactionAsync(int transactionId);
    }
}

using LMS_Api_App.Application.DTOs.TransactionDto;
using LMS_Api_App.Domain.Model;

namespace LMS_Api_App.Application.Interfaces.Repositories.TransactionRepository
{
    public interface ITransactionRepository
    {
        Task AddTransactionAsync(Transactions transactions);
        Task <bool>UpdateTransactionAsync(Transactions transactions);
        Task<IEnumerable<Transactions>> GetAllTransactionsAsync();
        Task<Transactions> GetTransactionByIdAsync(int transactionId);
        Task<bool> DeleteTransactionAsync(int transactionId);
    }

}

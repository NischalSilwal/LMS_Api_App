using LMS_Api_App.Application.Interfaces.Repositories.TransactionRepository;
using LMS_Api_App.Application.Interfaces.Services;
using LMS_Api_App.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_Api_App.Infrastructure.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public async Task AddTransactionAsync(Transactions transactions)
        {
            await _transactionRepository.AddTransactionAsync(transactions);
        }

        public async Task<bool> DeleteTransactionAsync(int transactionId)
        {
            return await _transactionRepository.DeleteTransactionAsync(transactionId);
        }

        public async Task<IEnumerable<Transactions>> GetAllTransactionsAsync()
        {
            return await _transactionRepository.GetAllTransactionsAsync();
        }

        public async Task<Transactions> GetTransactionByIdAsync(int transactionId)
        {
            return await _transactionRepository.GetTransactionByIdAsync(transactionId);
        }

        public async Task<bool> UpdateTransactionAsync(Transactions transactions)
        {
            return await _transactionRepository.UpdateTransactionAsync(transactions);
        }
    }
}

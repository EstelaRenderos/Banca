using Banca.Domain.Common;
using Banca.Domain.Entities;

namespace Banca.Domain.Interfaces
{
    public interface ITransactionRepository
    {
        Task<Transaction> GetTransactionByIdAsync(int transactionId);
        Task<List<Transaction>> GetAllAsync(int userId);
        Task<Result> CreateAsync(Transaction transaction);
        Task<Result> UpdateAsync(Transaction transaction);
        Task<Result> DeleteAsync(int id);
    }
}

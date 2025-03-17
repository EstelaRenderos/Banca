using Banca.Domain.Common;
using Banca.Domain.Entities;

namespace Banca.Domain.Interfaces
{
    public interface IAccountRepository
    {
        Task<Account> GetByIdAsync(int id);
        Task<List<Account>> GetAllAsync(int accountid);
        Task<Account> GetByAccountNumberAsync(string accountNumber);
        Task<Result> CreateAsync(Account account);
        Task<Result> UpdateAsync(Account account);
        Task<Result> DeleteAsync(int AccountId);
    }
}

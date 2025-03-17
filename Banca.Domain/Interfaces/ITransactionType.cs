using Banca.Domain.Entities;

namespace Banca.Domain.Interfaces
{
    public interface ITransactionTypeRepository
    {
        Task<TransactionType> GetTransactionTypeByIdAsync(int transactionTypeId);
        Task<TransactionType> GetTransactionTypeIdByCodeAsync(string TransactionTypeCode);

    }
}

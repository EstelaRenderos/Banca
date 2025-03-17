using Banca.Domain.Common;

namespace Banca.Application.Services.TransactionService
{
    public interface ITransactionService
    {
        Task<Result> ApplyTransactionAsync(int accountId, int transactionTypeId, decimal amount, string description);
        Task<Result> UpdateTransactionAsync(int transactionId, decimal newAmount, string newDescription);
    }
}

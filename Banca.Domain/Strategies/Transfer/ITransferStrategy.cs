using Banca.Domain.Common;
using Banca.Domain.Entities;

namespace Banca.Domain.Strategies.Transfer
{
    public interface ITransferStrategy
    {
        Task<Result> ExecuteAsync(Account fromAccount, Account toAccount, decimal amount);
    }
}

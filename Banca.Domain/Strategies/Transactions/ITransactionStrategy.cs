
using Banca.Domain.Common;
using Banca.Domain.Entities;

namespace Banca.Domain.Strategies.Transactions
{
    public interface ITransactionStrategy
    {
        Result Apply(Account account, decimal amount);
        Result Revert(Account account, decimal amount);
    }
}

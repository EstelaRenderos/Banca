using Banca.Domain.Common;
using Banca.Domain.Entities;

namespace Banca.Domain.Strategies.Transactions
{
    public class DepositStrategy : ITransactionStrategy
    {
        public Result Apply(Account account, decimal amount)
        {
            account.AccountBalance += amount;
            return Result.Success();
        }

        public Result Revert(Account account, decimal amount)
        {
            account.AccountBalance -= amount; 
            return Result.Success();
        }
    }
}

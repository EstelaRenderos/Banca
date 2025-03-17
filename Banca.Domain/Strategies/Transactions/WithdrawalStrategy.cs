using Banca.Domain.Common;
using Banca.Domain.Entities;

namespace Banca.Domain.Strategies.Transactions
{
    public class WithdrawalStrategy : ITransactionStrategy
    {
        public Result Apply(Account account, decimal amount)
        {
            if (account.AccountBalance < amount)
            {
                return Result.Failure("Fondos insuficientes.");
            }
            account.AccountBalance -= amount;
            return Result.Success();
        }

        public Result Revert(Account account, decimal amount)
        {
            account.AccountBalance += amount; 
            return Result.Success();
        }
    }
}

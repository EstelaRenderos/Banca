using Banca.Domain.Common;
using Banca.Domain.Entities;

namespace Banca.Domain.Strategies.Transfer
{
    public class InternationalTransferStrategy : ITransferStrategy
    {
        public async Task<Result> ExecuteAsync(Account fromAccount, Account toAccount, decimal amount)
        {
            if (fromAccount.AccountBalance < amount)
            {
                return Result.Failure("No se cuenta con fondos suficientes.");
            }

            fromAccount.AccountBalance -= amount;
            toAccount.AccountBalance += amount;

            return Result.Success("Transferencia internacional realizada con éxito.");
        }
    }
}

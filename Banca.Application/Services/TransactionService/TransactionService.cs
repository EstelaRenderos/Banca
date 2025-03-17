using Banca.Domain.Common;
using Banca.Domain.Entities;
using Banca.Domain.Interfaces;
using Banca.Domain.Strategies.Transactions;

namespace Banca.Application.Services.TransactionService
{
    public class TransactionService : ITransactionService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly ITransactionTypeRepository _transactionTypeRepository;

        public TransactionService(IAccountRepository accountRepository, ITransactionRepository transactionRepository, ITransactionTypeRepository transactionTypeRepository)
        {
            _accountRepository = accountRepository;
            _transactionRepository = transactionRepository;
            _transactionTypeRepository = transactionTypeRepository;
        }

        public async Task<Result> ApplyTransactionAsync(int accountId, int transactionTypeId, decimal amount, string description)
        {
            var account = await _accountRepository.GetByIdAsync(accountId);
            if (account == null)
            {
                return Result.Failure("Cuenta no encontrada.");
            }

            var transactionType = await _transactionTypeRepository.GetTransactionTypeByIdAsync(transactionTypeId);
            if (transactionType == null)
            {
                return Result.Failure("Tipo de transacción no válido.");
            }

            var strategy = TransactionStrategyFactory.GetStrategy(transactionType.TransactionTypeCode);
            if (strategy == null)
            {
                return Result.Failure("Tipo de transacción no soportado.");
            }

            var result = strategy.Apply(account, amount);
            if (!result.IsSuccess)
            {
                return result;
            }
            await _accountRepository.UpdateAsync(account);

            var transaction = new Transaction
            {
                AccountId = accountId,
                TransactionTypeId = transactionTypeId,
                Amount = amount,
                Description = description
            };

            return await _transactionRepository.CreateAsync(transaction);
        }

        public async Task<Result> UpdateTransactionAsync(int transactionId, decimal newAmount, string newDescription)
        {
            var transaction = await _transactionRepository.GetTransactionByIdAsync(transactionId);
            if (transaction == null)
            {
                return Result.Failure("Transacción no encontrada.");
            }

            var account = await _accountRepository.GetByIdAsync(transaction.AccountId);
            if (account == null)
            {
                return Result.Failure("Cuenta no encontrada.");
            }

            var transactionType = await _transactionTypeRepository.GetTransactionTypeByIdAsync(transaction.TransactionTypeId);
            if (transactionType == null)
            {
                return Result.Failure("Tipo de transacción no válido.");
            }

            var strategy = TransactionStrategyFactory.GetStrategy(transactionType.TransactionTypeCode);
            if (strategy == null)
            {
                return Result.Failure("Tipo de transacción no soportado.");
            }

            var revertResult = strategy.Revert(account, transaction.Amount);
            if (!revertResult.IsSuccess)
            {
                return revertResult;
            }

            var applyResult = strategy.Apply(account, newAmount);
            if (!applyResult.IsSuccess)
            {
                return applyResult;
            }

            await _accountRepository.UpdateAsync(account);

            transaction.Amount = newAmount;
            transaction.Description = newDescription;

            return await _transactionRepository.UpdateAsync(transaction);
        }
    }
}

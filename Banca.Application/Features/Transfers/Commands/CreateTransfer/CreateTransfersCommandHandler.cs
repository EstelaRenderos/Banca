using Banca.Application.Services.TransactionService;
using Banca.Domain.Common;
using Banca.Domain.Entities;
using Banca.Domain.Interfaces;
using MediatR;

namespace Banca.Application.Features.Transfers.Commands.CreateTransfer
{
    public class CreateTransferCommandHandler(
        ITransferRepository transferRepository,
        IAccountRepository accountRepository,
        ITransferTypeRepository transferTypeRepository,
        ITransactionTypeRepository transactionTypeRepository,
        ITransactionService transactionService
        ) : IRequestHandler<CreateTransferCommand, Result>
    {
        private readonly ITransferRepository _transferRepository = transferRepository;
        private readonly IAccountRepository _accountRepository = accountRepository;
        private readonly ITransferTypeRepository _transferTypeRepository = transferTypeRepository;
        private readonly ITransactionTypeRepository _transactionTypeRepository = transactionTypeRepository;
        private readonly ITransactionService _transactionService = transactionService;
        public async Task<Result> Handle(CreateTransferCommand request, CancellationToken cancellationToken)
        {
            var fromAccount = await _accountRepository.GetByIdAsync(request.SourceAccountId);
            var toAccount = await _accountRepository.GetByIdAsync(request.DestinationAccountId);

            if (fromAccount == null)
                return Result.Failure("La Cuenta de Origen no Existe.");
            if (toAccount == null)
                return Result.Failure("La Cuenta de Destino no Existe.");

            if (fromAccount.AccountBalance < request.Amount)
                return Result.Failure("No se cuenta con fondos suficientes.");

            var transferType = await _transferTypeRepository.GetTransferTypeByIdAsync(request.TransferTypeId);

            if (transferType == null)
                return Result.Failure("El Tipo de Transferencia no Existe.");

            var resultFrom = await _accountRepository.UpdateAsync(fromAccount);
            var resultTo = await _accountRepository.UpdateAsync(toAccount);
            if (resultFrom.IsSuccess && resultTo.IsSuccess)
            {

                var transactionType = await transactionTypeRepository.GetTransactionTypeIdByCodeAsync("TRF_PROPIAS");
                
                var withdrawalResult = await _transactionService.ApplyTransactionAsync(
                    fromAccount.Id,
                    transactionType.Id, 
                    -request.Amount, 
                    $"Transferencia a la cuenta {toAccount.AccountNumber}"
                );

                if (!withdrawalResult.IsSuccess)
                {
                    return withdrawalResult;
                }

                var depositResult = await _transactionService.ApplyTransactionAsync(
                    toAccount.Id,
                    transactionType.Id,
                    request.Amount,
                    $"Transferencia desde la cuenta {fromAccount.AccountNumber}"
                );

                if (!depositResult.IsSuccess)
                {
                    return depositResult;
                }

                var transfer = new Transfer
                {
                    UserId = request.UserId,
                    SourceAccountId = request.SourceAccountId,
                    DestinationAccountId = request.DestinationAccountId,
                    Amount = request.Amount,
                    DateApplication = request.DateApplication,
                    TransferTypeId = request.TransferTypeId
                };

                await transferRepository.CreateAsync(transfer);
                return Result.Success("La Transferencia se realizó exitosamente.");
            }

            return Result.Failure("Sucedió un error al intentar generar la transferencia.");
        }
    }
}

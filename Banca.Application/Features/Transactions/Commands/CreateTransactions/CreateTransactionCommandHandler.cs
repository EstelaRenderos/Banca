using Banca.Application.Services.TransactionService;
using Banca.Domain.Common;
using MediatR;

namespace Banca.Application.Features.Transactions.Commands.CreateTransactions
{
    public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, Result>
    {
        private readonly ITransactionService _transactionService;

        public CreateTransactionCommandHandler(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public async Task<Result> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            return await _transactionService.ApplyTransactionAsync(
                request.AccountId,
                request.TransactionTypeId,
                request.Amount,
                request.Description
            );
        }
    }
}

using Banca.Application.Services.TransactionService;
using Banca.Domain.Common;
using MediatR;

namespace Banca.Application.Features.Transactions.Commands.UpdateTransactions
{
    public class UpdateTransactionCommandHandler : IRequestHandler<UpdateTransactionCommand, Result>
    {
        private readonly ITransactionService _transactionService;

        public UpdateTransactionCommandHandler(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public async Task<Result> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
        {
            return await _transactionService.UpdateTransactionAsync(request.id, request.Amount, request.Description);
        }
    }
}

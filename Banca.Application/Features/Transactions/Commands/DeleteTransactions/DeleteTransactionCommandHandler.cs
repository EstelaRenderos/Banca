using Banca.Domain.Common;
using Banca.Domain.Interfaces;
using MediatR;

namespace Banca.Application.Features.Transactions.Commands.DeleteTransactions
{
    public class DeleteTransactionCommandHandler : IRequestHandler<DeleteTransactionCommand, Result>
    {
        private readonly ITransactionRepository _TransactionRepository;

        public DeleteTransactionCommandHandler(ITransactionRepository TransactionRepository)
        {
            _TransactionRepository = TransactionRepository;
        }

        public async Task<Result> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
        {
            return await _TransactionRepository.DeleteAsync(request.id);
        }
    }
}

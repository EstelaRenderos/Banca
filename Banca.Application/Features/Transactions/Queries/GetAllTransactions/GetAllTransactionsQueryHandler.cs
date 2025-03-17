using Banca.Domain.Common;
using Banca.Domain.Interfaces;
using MediatR;

namespace Banca.Application.Features.Transactions.Queries.GetAllTransactions
{
    public class GetAllTransactionsQueryHandler : IRequestHandler<GetAllTransactionsQuery, Result>
    {
        private readonly ITransactionRepository _TransactionRepository;

        public GetAllTransactionsQueryHandler(ITransactionRepository TransactionRepository)
        {
            _TransactionRepository = TransactionRepository;
        }

        public async Task<Result> Handle(GetAllTransactionsQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var transactions = await _TransactionRepository.GetAllAsync(query.UserId);
                return Result.Success(transactions);
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }
    }
}

using Banca.Domain.Common;
using Banca.Domain.Interfaces;
using MediatR;

namespace Banca.Application.Features.Transactions.Queries.GetTransactionById
{
    public class GetTransactionByIdQueryHandler : IRequestHandler<GetTransactionByIdQuery, Result>
    {
        private readonly ITransactionRepository _TransactionRepository;

        public GetTransactionByIdQueryHandler(ITransactionRepository TransactionRepository)
        {
            _TransactionRepository = TransactionRepository;
        }

        public async Task<Result> Handle(GetTransactionByIdQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var transactions = await _TransactionRepository.GetTransactionByIdAsync(query.Id);
                return Result.Success(transactions);
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }
    }
}

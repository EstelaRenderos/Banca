using Banca.Domain.Common;
using Banca.Domain.Interfaces;
using MediatR;

namespace Banca.Application.Features.TransactionType.Queries.GetTransactionIdByCode
{
    public class GetTransactionTypeIdByCodeQuery : IRequestHandler<GetTransactionTypeByCodeQuery, Result>
    {
        private readonly ITransactionTypeRepository _TransactionTypeRepository;

        public GetTransactionTypeIdByCodeQuery(ITransactionTypeRepository TransactionTypeRepository)
        {
            _TransactionTypeRepository = TransactionTypeRepository;
        }

        public async Task<Result> Handle(GetTransactionTypeByCodeQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var transactions = await _TransactionTypeRepository.GetTransactionTypeIdByCodeAsync(query.TransactionTypeCode);
                return Result.Success(transactions);
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }
    }
}

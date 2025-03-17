using Banca.Domain.Common;
using Banca.Domain.Interfaces;
using MediatR;

namespace Banca.Application.Features.TransactionType.Queries.GetTransactionTypeById
{
    public class GetTransactionTypeByIdQueryHandler : IRequestHandler<GetTransactionTypeByIdQuery, Result>
    {
        private readonly ITransactionTypeRepository _TransactionTypeRepository;

        public GetTransactionTypeByIdQueryHandler(ITransactionTypeRepository TransactionTypeRepository)
        {
            _TransactionTypeRepository = TransactionTypeRepository;
        }

        public async Task<Result> Handle(GetTransactionTypeByIdQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var TransactionTypes = await _TransactionTypeRepository.GetTransactionTypeByIdAsync(query.Id);
                return Result.Success(TransactionTypes);
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }
    }
}

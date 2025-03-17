using Banca.Domain.Common;
using MediatR;
namespace Banca.Application.Features.TransactionType.Queries.GetTransactionIdByCode
{
    public class GetTransactionTypeByCodeQuery : IRequest<Result>
    {
        public string TransactionTypeCode { get; set; }
    }
}

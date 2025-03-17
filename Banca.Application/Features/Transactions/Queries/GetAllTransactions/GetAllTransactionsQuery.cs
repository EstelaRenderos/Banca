using Banca.Domain.Common;
using MediatR;

namespace Banca.Application.Features.Transactions.Queries.GetAllTransactions
{
    public class GetAllTransactionsQuery : IRequest<Result>
    {
        public int UserId { get; set; }
    }
}

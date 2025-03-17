using Banca.Domain.Common;
using MediatR;
namespace Banca.Application.Features.Transactions.Queries.GetTransactionById
{
    public class GetTransactionByIdQuery : IRequest<Result>
    {
        public int Id { get; set; }
    }
}

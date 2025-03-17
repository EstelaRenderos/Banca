using Banca.Domain.Common;
using MediatR;
namespace Banca.Application.Features.TransactionType.Queries.GetTransactionTypeById
{
    public class GetTransactionTypeByIdQuery : IRequest<Result>
    {
        public int Id { get; set; }
    }
}

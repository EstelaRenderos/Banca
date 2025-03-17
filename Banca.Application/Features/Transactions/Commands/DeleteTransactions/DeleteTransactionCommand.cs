using Banca.Domain.Common;
using MediatR;

namespace Banca.Application.Features.Transactions.Commands.DeleteTransactions
{
    public class DeleteTransactionCommand : IRequest<Result>
    {
        public int id { get; set; }
    }
}

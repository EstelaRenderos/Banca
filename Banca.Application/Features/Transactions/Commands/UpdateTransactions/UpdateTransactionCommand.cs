using Banca.Domain.Common;
using MediatR;
namespace Banca.Application.Features.Transactions.Commands.UpdateTransactions
{
    public class UpdateTransactionCommand : IRequest<Result>
    {
        public int id { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
    }
}

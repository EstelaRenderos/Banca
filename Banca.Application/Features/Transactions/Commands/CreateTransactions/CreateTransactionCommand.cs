using Banca.Domain.Common;
using MediatR;

namespace Banca.Application.Features.Transactions.Commands.CreateTransactions
{
    public class CreateTransactionCommand : IRequest<Result>
    {
        public int AccountId { get; set; }
        public int TransactionTypeId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
    }
}
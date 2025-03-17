using Banca.Domain.Common;
using MediatR;

namespace Banca.Application.Features.Transfers.Commands.CreateTransfer
{
    public class CreateTransferCommand : IRequest<Result>
    {
        public int UserId { get; set; }
        public int SourceAccountId { get; set; }
        public int DestinationAccountId { get; set; }
        public int TransferTypeId { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateApplication { get; set; } = DateTime.Now;
    }
}

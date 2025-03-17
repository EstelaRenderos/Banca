using Banca.Domain.Common;
using MediatR;

namespace Banca.Application.Features.Transfers.Commands.UpdateTransfer
{
    public class UpdateTransferCommand : IRequest<Result>
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateApplication { get; set; } = DateTime.Now;
    }
}

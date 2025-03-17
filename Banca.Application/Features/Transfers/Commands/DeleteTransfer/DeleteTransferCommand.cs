using Banca.Domain.Common;
using MediatR;

namespace Banca.Application.Features.Transfers.Commands.DeleteTransfer
{
    public class DeleteTransferCommand : IRequest<Result>
    {
        public int id { get; set; }
    }
}

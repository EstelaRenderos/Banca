using Banca.Domain.Common;
using Banca.Domain.Interfaces;
using MediatR;

namespace Banca.Application.Features.Transfers.Commands.DeleteTransfer
{
    public class DeleteTransferCommandHandler : IRequestHandler<DeleteTransferCommand, Result>
    {
        private readonly ITransferRepository _TransferRepository;

        public DeleteTransferCommandHandler(ITransferRepository TransferRepository)
        {
            _TransferRepository = TransferRepository;
        }

        public async Task<Result> Handle(DeleteTransferCommand request, CancellationToken cancellationToken)
        {
             await _TransferRepository.DeleteAsync(request.id);
             return Result.Success();
        }
    }
}

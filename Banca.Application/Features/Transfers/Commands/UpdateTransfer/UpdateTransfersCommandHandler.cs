using Banca.Domain.Interfaces;
using MediatR;
using Banca.Domain.Entities;
using Banca.Domain.Common;
using System.Threading.Tasks;
using System.Threading;

namespace Banca.Application.Features.Transfers.Commands.UpdateTransfer
{
    public class UpdateTransferCommandHandler : IRequestHandler<UpdateTransferCommand, Result>
    {
        private readonly ITransferRepository _transferRepository;

        public UpdateTransferCommandHandler(ITransferRepository transferRepository)
        {
            _transferRepository = transferRepository;
        }

        public async Task<Result> Handle(UpdateTransferCommand request, CancellationToken cancellationToken)
        {
            var existingTransfer = await _transferRepository.GetByIdAsync(request.Id);
            if (existingTransfer == null)
            {
                return Result.Failure($"Transferencia con ID {request.Id} no encontrada.");
            }

            existingTransfer.Amount = request.Amount;
            existingTransfer.DateApplication = request.DateApplication;

            await _transferRepository.UpdateAsync(existingTransfer);

            return Result.Success();
        }
    }
}
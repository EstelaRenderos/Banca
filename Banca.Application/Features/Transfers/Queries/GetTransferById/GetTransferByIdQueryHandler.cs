using Banca.Domain.Common;
using Banca.Domain.Entities;
using Banca.Domain.Interfaces;
using MediatR;

namespace Banca.Application.Features.Transfers.Queries.GetTransferById
{
    public class GetTransferByIdQueryHandler : IRequestHandler<GetTransferByIdQuery, Result>
    {
        private readonly ITransferRepository _TransferRepository;

        public GetTransferByIdQueryHandler(ITransferRepository TransferRepository)
        {
            _TransferRepository = TransferRepository;
        }

        public async Task<Result> Handle(GetTransferByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var transfer = await _TransferRepository.GetByIdAsync(request.Id);
                return Result.Success(transfer);
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }
    }
}

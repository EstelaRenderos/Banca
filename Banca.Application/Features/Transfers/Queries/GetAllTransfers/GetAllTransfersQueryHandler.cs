using Banca.Domain.Common;
using Banca.Domain.Interfaces;
using MediatR;

namespace Banca.Application.Features.Transfers.Queries.GetAllTransfers
{
    public class GetAllTransfersQueryHandler : IRequestHandler<GetAllTransfersQuery, Result>
    {
        private readonly ITransferRepository _TransferRepository;

        public GetAllTransfersQueryHandler(ITransferRepository TransferRepository)
        {
            _TransferRepository = TransferRepository;
        }

        public async Task<Result> Handle(GetAllTransfersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var transfers = await _TransferRepository.GetAllAsync(request.UserId);
                return Result.Success(transfers);
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }
    }
}

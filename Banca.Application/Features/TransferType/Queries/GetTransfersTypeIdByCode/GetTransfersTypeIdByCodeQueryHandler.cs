using Banca.Domain.Common;
using Banca.Domain.Interfaces;
using MediatR;

namespace Banca.Application.Features.TransferType.Queries.GetTransfersTypeIdByCode
{
    public class GetTransfersTypeIdByCodeQueryHandler : IRequestHandler<GetTransfersTypeIdByCodeQuery, Result>
    {
        private readonly ITransferTypeRepository _TransferTypeRepository;

        public GetTransfersTypeIdByCodeQueryHandler(ITransferTypeRepository TransferTypeRepository)
        {
            _TransferTypeRepository = TransferTypeRepository;
        }

        public async Task<Result> Handle(GetTransfersTypeIdByCodeQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var transferstype = await _TransferTypeRepository.GetTransferTypeIdByCodeAsync(request.TransferTypeCode);
                return Result.Success(transferstype);
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }
    }
}

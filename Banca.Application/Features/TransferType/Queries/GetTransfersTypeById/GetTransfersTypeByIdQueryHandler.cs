
using Banca.Domain.Common;
using Banca.Domain.Interfaces;
using MediatR;

namespace Banca.Application.Features.TransferType.Queries.GetTransfersTypeById
{
    public class GetTransfersTypeByIdQueryHandler : IRequestHandler<GetTransfersTypeByIdQuery, Result>
    {
        private readonly ITransferTypeRepository _TransferTypeRepository;

        public GetTransfersTypeByIdQueryHandler(ITransferTypeRepository TransferTypeRepository)
        {
            _TransferTypeRepository = TransferTypeRepository;
        }

        public async Task<Result> Handle(GetTransfersTypeByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var transferstype = await _TransferTypeRepository.GetTransferTypeByIdAsync(request.id);
                return Result.Success(transferstype);
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }
    }
}

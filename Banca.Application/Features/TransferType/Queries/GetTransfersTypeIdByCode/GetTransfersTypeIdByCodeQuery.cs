using Banca.Domain.Common;
using MediatR;

namespace Banca.Application.Features.TransferType.Queries.GetTransfersTypeIdByCode
{
    public class GetTransfersTypeIdByCodeQuery : IRequest<Result>
    {
        public string TransferTypeCode { get; set; }
    }
}

using Banca.Domain.Common;
using MediatR;

namespace Banca.Application.Features.TransferType.Queries
{
    public class GetTransfersTypeByIdQuery : IRequest<Result>
    {
        public int id { get; set; }
    }
}

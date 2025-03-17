using Banca.Domain.Common;
using MediatR;

namespace Banca.Application.Features.Transfers.Queries.GetAllTransfers
{
    public class GetAllTransfersQuery : IRequest<Result>
    {
        public int UserId { get; set; }
    }
}

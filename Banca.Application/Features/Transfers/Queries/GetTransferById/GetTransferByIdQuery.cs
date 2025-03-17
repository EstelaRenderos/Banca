using Banca.Domain.Common;
using MediatR;

namespace Banca.Application.Features.Transfers.Queries.GetTransferById
{
    public class GetTransferByIdQuery : IRequest<Result>
    {
        public int Id { get; set; }
    }
}

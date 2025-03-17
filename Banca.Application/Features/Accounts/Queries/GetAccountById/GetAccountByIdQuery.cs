using Banca.Domain.Common;
using MediatR;

namespace Banca.Application.Features.Accounts.Queries.GetAccountById
{
    public class GetAccountByIdQuery : IRequest<Result>
    {
        public int Id { get; set; }
    }
}

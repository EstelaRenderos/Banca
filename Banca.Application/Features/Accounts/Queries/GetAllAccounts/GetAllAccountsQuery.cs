using Banca.Domain.Common;
using MediatR;

namespace Banca.Application.Features.Accounts.Queries.GetAllAccounts
{
    public class GetAllAccountQuery : IRequest<Result>
    {
        public int UserId { get; set; }
    }
}

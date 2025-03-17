using Banca.Domain.Common;
using MediatR;

namespace Banca.Application.Features.Accounts.Commands.DeleteAccounts
{
    public class DeleteAccountCommand : IRequest<Result>
    {
        public int id { get; set; }
    }
}

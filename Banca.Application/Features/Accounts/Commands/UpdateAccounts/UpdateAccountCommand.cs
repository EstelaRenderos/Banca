using Banca.Domain.Common;
using MediatR;

namespace Banca.Application.Features.Accounts.Commands.UpdateAccounts
{
    public class UpdateAccountCommand : IRequest<Result>
    {
        public int id { get; set; }
        public decimal AccountBalance { get; set; } = 0.00m;
    }
}

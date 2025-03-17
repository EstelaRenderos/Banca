using Banca.Domain.Common;
using Banca.Domain.Entities;
using MediatR;

namespace Banca.Application.Features.Accounts.Commands.CreateAccounts
{
    public class CreateAccountCommand : IRequest<Result>
    {
        public int UserId { get; set; }
        public string AccountNumber { get; set; }
        public decimal AccountBalance { get; set; } = 0.00m;
        public int AccountTypeId { get; set; }
    }
}

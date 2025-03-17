using Banca.Domain.Common;
using Banca.Domain.Entities;
using Banca.Domain.Interfaces;
using MediatR;

namespace Banca.Application.Features.Accounts.Commands.UpdateAccounts
{
    public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand, Result>
    {
        private readonly IAccountRepository _accountRepository;

        public UpdateAccountCommandHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<Result> Handle(UpdateAccountCommand command, CancellationToken cancellationToken)
        {


            var account = new Account
            {
                Id = command.id,
                AccountBalance = command.AccountBalance,
            };

            return await _accountRepository.UpdateAsync(account);
        }
    }
}

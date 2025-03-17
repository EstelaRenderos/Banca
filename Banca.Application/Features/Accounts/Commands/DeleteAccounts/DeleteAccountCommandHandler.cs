using Banca.Domain.Common;
using Banca.Domain.Interfaces;
using MediatR;

namespace Banca.Application.Features.Accounts.Commands.DeleteAccounts
{
    public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand, Result>
    {
        private readonly IAccountRepository _accountRepository;

        public DeleteAccountCommandHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<Result> Handle(DeleteAccountCommand command, CancellationToken cancellationToken)
        {
            return await _accountRepository.DeleteAsync(command.id);
        }
    }
}

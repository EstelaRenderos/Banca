using MediatR;
using Banca.Domain.Common;
using Banca.Domain.Interfaces;
using Banca.Domain.Entities;

namespace Banca.Application.Features.Accounts.Commands.CreateAccounts
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, Result>
    {
        private readonly IAccountRepository _accountRepository;

        public CreateAccountCommandHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<Result> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingAccount = await _accountRepository.GetByAccountNumberAsync(request.AccountNumber);
                if (existingAccount != null)
                {
                    return Result.Failure("La cuenta ya existe.");
                }

                var account = new Account
                {
                    UserId = request.UserId,
                    AccountNumber = request.AccountNumber,
                    AccountBalance = request.AccountBalance,
                    AccountTypeId = request.AccountTypeId
                };

                return await _accountRepository.CreateAsync(account);
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message); 
            }
        }
    }
}
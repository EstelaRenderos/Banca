using Banca.Domain.Common;
using Banca.Domain.Interfaces;
using MediatR;

namespace Banca.Application.Features.Accounts.Queries.GetAllAccounts
{
    public class GetAllAccountsQueryHandler : IRequestHandler<GetAllAccountQuery, Result>
    {
        private readonly IAccountRepository _accountRepository;

        public GetAllAccountsQueryHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<Result> Handle(GetAllAccountQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var accounts = await _accountRepository.GetAllAsync(query.UserId);
                return Result.Success(accounts);
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }
    }
}

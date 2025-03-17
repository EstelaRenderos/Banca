using MediatR;
using Banca.Domain.Interfaces;
using Banca.Domain.Common;

namespace Banca.Application.Features.Accounts.Queries.GetAccountById
{
    public class GetAccountByIdQueryHandler : IRequestHandler<GetAccountByIdQuery, Result>
    {
        private readonly IAccountRepository _accountRepository;

        public GetAccountByIdQueryHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<Result> Handle(GetAccountByIdQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var accounts = await _accountRepository.GetByIdAsync(query.Id);
                if (accounts is null)
                    return Result.Failure("No se encontró ninguna cuenta con el ID proporcionado");

                return Result.Success(accounts);
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }
    }
}

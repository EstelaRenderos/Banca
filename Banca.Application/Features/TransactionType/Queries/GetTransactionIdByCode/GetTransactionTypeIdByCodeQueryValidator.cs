using Banca.Application.Features.Transactions.Commands.CreateTransactions;
using FluentValidation;

namespace Banca.Application.Features.TransactionType.Queries.GetTransactionIdByCode
{
    public class GetTransactionTypeIdByCodeQueryValidator : AbstractValidator<CreateTransactionCommand>
    {
        public GetTransactionTypeIdByCodeQueryValidator()
        {
            RuleFor(x => x.AccountId)
                .NotEmpty().WithMessage("El ID de la Cuenta es obligatorio.")
                .GreaterThan(0).WithMessage("El ID de la Cuenta debe ser mayor que 0.");
        }
    }
}

using FluentValidation;

namespace Banca.Application.Features.Transactions.Commands.DeleteTransactions
{
    public class CreateTransactionCommandValidator : AbstractValidator<DeleteTransactionCommand>
    {
        public CreateTransactionCommandValidator()
        {
            RuleFor(x => x.id)
                .NotEmpty().WithMessage("El ID de la transaction es requerido.")
                .GreaterThan(0).WithMessage("El ID de la transaction debe ser mayor que 0.");
        }
    }
}

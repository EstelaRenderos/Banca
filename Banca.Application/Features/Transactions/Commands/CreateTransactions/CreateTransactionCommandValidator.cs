using Banca.Application.Features.Transactions.Commands.CreateTransactions;
using FluentValidation;

namespace Banca.Application.Features.Transactions.Commands
{
    public class UpdateTransactionCommandValidator : AbstractValidator<CreateTransactionCommand>
    {
        public UpdateTransactionCommandValidator()
        {
            RuleFor(x => x.AccountId)
                .NotEmpty().WithMessage("El ID de la Cuenta es obligatorio.")
                .GreaterThan(0).WithMessage("El ID de la Cuenta debe ser mayor que 0.");

            RuleFor(x => x.TransactionTypeId)
                .NotEmpty().WithMessage("El tipo de transacción es obligatorio.")
                .GreaterThan(0).WithMessage("El tipo de transacción debe ser mayor que 0.");

            RuleFor(x => x.Amount)
                .NotEmpty().WithMessage("El monto es obligatorio.")
                .GreaterThan(0).WithMessage("El monto debe ser mayor que 0.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("La descripción es obligatoria.")
                .MaximumLength(500).WithMessage("La descripción no puede exceder los 500 caracteres.");
        }
    }
}
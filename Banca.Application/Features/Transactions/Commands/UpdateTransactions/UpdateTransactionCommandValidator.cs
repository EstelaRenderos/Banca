using FluentValidation;

namespace Banca.Application.Features.Transactions.Commands.UpdateTransactions
{
    public class UpdateTransactionCommandValidator : AbstractValidator<UpdateTransactionCommand>
    {
        public UpdateTransactionCommandValidator()
        {
            RuleFor(x => x.id)
                .NotEmpty().WithMessage("El ID de la Transactión es obligatorio.")
                .GreaterThan(0).WithMessage("El ID de la Transactión debe ser mayor que 0.");

            RuleFor(x => x.Amount)
                .NotEmpty().WithMessage("El monto es obligatorio.")
                .GreaterThan(0).WithMessage("El monto debe ser mayor que 0.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("La descripción es obligatoria.")
                .MaximumLength(500).WithMessage("La descripción no puede exceder los 500 caracteres.");
        }
    }
}
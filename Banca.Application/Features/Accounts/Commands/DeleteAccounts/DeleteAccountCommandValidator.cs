using FluentValidation;
namespace Banca.Application.Features.Accounts.Commands.DeleteAccounts
{
    public class DeleteAccountCommandValidator : AbstractValidator<DeleteAccountCommand>
    {
        public DeleteAccountCommandValidator()
        {
            RuleFor(x => x.id)
                .NotEmpty().WithMessage("El ID de la cuenta es requerido.")
                .GreaterThan(0).WithMessage("El ID de la cuenta debe ser mayor que 0.");
        }
    }
}

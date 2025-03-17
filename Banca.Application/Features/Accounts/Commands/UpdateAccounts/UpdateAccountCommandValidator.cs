using FluentValidation;
namespace Banca.Application.Features.Accounts.Commands.UpdateAccounts
{
    public class UpdateAccountCommandValidator : AbstractValidator<UpdateAccountCommand>
    {
        public UpdateAccountCommandValidator()
        {
            RuleFor(x => x.id)
                .NotEmpty().WithMessage("El ID de la cuenta es requerido.")
                .GreaterThan(0).WithMessage("El ID de la cuenta debe ser mayor que 0.");

            RuleFor(x => x.AccountBalance)
                .GreaterThanOrEqualTo(0).WithMessage("El saldo de la cuenta no puede ser negativo.");
        }
    }
}

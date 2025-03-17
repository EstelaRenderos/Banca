using FluentValidation;

namespace Banca.Application.Features.Accounts.Commands.CreateAccounts
{
    public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand>
    {
        public CreateAccountCommandValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("El ID del usuario es requerido.")
                .GreaterThan(0).WithMessage("El ID del usuario debe ser mayor que 0.");

            RuleFor(x => x.AccountNumber)
                .NotEmpty().WithMessage("El número de cuenta es requerido.")
                .Length(10, 20).WithMessage("El número de cuenta debe tener entre 10 y 20 caracteres.");

            RuleFor(x => x.AccountBalance)
                .GreaterThanOrEqualTo(0).WithMessage("El saldo de la cuenta no puede ser negativo.");

            RuleFor(x => x.AccountTypeId)
                .NotEmpty().WithMessage("El tipo de cuenta es requerido.")
                .GreaterThan(0).WithMessage("El ID del tipo de cuenta debe ser mayor que 0.");
        }
    }
}
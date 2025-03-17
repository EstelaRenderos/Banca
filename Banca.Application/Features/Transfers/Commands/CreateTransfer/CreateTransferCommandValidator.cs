using Banca.Application.Features.Transfers.Commands.CreateTransfer;
using FluentValidation;

namespace Banca.Application.Features.Transfers.Commands
{
    public class CreateTransferCommandValidator : AbstractValidator<CreateTransferCommand>
    {
        public CreateTransferCommandValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("El ID del usuario es obligatorio.")
                .GreaterThan(0).WithMessage("El ID del usuario debe ser mayor que 0.");

            RuleFor(x => x.SourceAccountId)
                .NotEmpty().WithMessage("El ID de la cuenta de origen es obligatorio.")
                .GreaterThan(0).WithMessage("El ID de la cuenta de origen debe ser mayor que 0.");

            RuleFor(x => x.DestinationAccountId)
                .NotEmpty().WithMessage("El ID de la cuenta de destino es obligatorio.")
                .GreaterThan(0).WithMessage("El ID de la cuenta de destino debe ser mayor que 0.")
                .NotEqual(x => x.SourceAccountId).WithMessage("La cuenta de origen y la cuenta de destino no pueden ser la misma.");

            RuleFor(x => x.TransferTypeId)
                .NotEmpty().WithMessage("El ID de la transferencia es obligatorio.")
                .GreaterThan(0).WithMessage("El ID de la transferencia debe ser mayor que 0.");

            RuleFor(x => x.Amount)
                .NotEmpty().WithMessage("El monto es obligatorio.")
                .GreaterThan(0).WithMessage("El monto debe ser mayor que 0.");

            RuleFor(x => x.DateApplication)
                .NotEmpty().WithMessage("La fecha de aplicación es obligatoria.");
        }
    }
}
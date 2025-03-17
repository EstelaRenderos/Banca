using Banca.Application.Features.Transfers.Commands.UpdateTransfer;
using FluentValidation;

namespace Banca.Application.Features.Transfers.Commands
{
    public class UpdateTransferCommandValidator : AbstractValidator<UpdateTransferCommand>
    {
        public UpdateTransferCommandValidator()
        {
            RuleFor(x => x.Id)
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
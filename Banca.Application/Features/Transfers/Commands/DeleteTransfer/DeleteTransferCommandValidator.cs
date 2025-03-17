using Banca.Application.Features.Transfers.Commands.DeleteTransfer;
using FluentValidation;

namespace Banca.Application.Features.Transfers.Commands.DeleteTransfer
{
    public class DeleteTransferCommandValidator : AbstractValidator<DeleteTransferCommand>
    {
        public DeleteTransferCommandValidator()
        {
            RuleFor(x => x.id)
                .NotEmpty().WithMessage("El ID de la transferencia es obligatorio.")
                .GreaterThan(0).WithMessage("El ID de la transferencia debe ser mayor que 0.");
        }
    }
}

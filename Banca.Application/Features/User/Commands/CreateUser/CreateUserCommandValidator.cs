using FluentValidation;
using Banca.Application.DTOs.User;

namespace Banca.Application.Features.User.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El nombre es requerido")
                .MaximumLength(100).WithMessage("El nombre no puede exceder los 100 caracteres");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("El correo electrónico es requerido")
                .EmailAddress().WithMessage("El correo electrónico no es válido");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("La contraseña es requerida")
                .MinimumLength(6).WithMessage("La contraseña debe tener al menos 6 caracteres");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("El teléfono es requerido")
                .Matches(@"^\d{8}$").WithMessage("El teléfono debe tener 8 dígitos");

            RuleFor(x => x.BirthDate)
                .NotEmpty().WithMessage("La fecha de nacimiento es requerida")
                .Must(BeAValidDate).WithMessage("La fecha de nacimiento no es válida");
        }

        private bool BeAValidDate(DateTime date)
        {
            return date < DateTime.Now;
        }
    }
}
using FluentValidation;
using Banca.Application.DTOs;

namespace Banca.Application.Features.Auth.Commands.Login
{
    public class LoginValidator : AbstractValidator<LoginRequest>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("El nombre de usuario es requerido")
                .MinimumLength(3).WithMessage("El nombre de usuario debe tener al menos 3 caracteres");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("La contraseña es requerida")
                .MinimumLength(6).WithMessage("La contraseña debe tener al menos 6 caracteres");
        }
    }
}
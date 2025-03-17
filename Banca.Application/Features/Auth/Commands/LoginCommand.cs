using MediatR;
using Banca.Application.DTOs;

namespace Banca.Application.Features.Auth.Commands
{
    public class LoginCommand : IRequest<LoginResponse>
    {
        public LoginRequest LoginRequest { get; set; }
    }
}
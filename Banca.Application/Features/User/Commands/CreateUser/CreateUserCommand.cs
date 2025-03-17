using MediatR;
using Banca.Domain.Common;
using Banca.Application.DTOs.User;

namespace Banca.Application.Features.User.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<Result>
    {
        public CreateUserRequest UserRequest { get; set; }
    }
}
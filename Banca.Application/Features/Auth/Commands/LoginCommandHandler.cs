using MediatR;
using Banca.Application.DTOs;
using Banca.Core.Interfaces;
using Banca.Application.Services;

namespace Banca.Application.Features.Auth.Commands
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtService _jwtService;

        public LoginCommandHandler(IUserRepository userRepository, JwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task<LoginResponse> Handle(LoginCommand command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByUsernameAsync(command.LoginRequest.Username);
            
            if (user == null)
                throw new UnauthorizedAccessException("Usuario o contraseña incorrectos");

            var decryptedPassword = AesEncryption.Decrypt(user.EncryptedPassword);

            if (command.LoginRequest.Password != decryptedPassword)
                throw new UnauthorizedAccessException("Usuario o contraseña incorrectos");

            var token = _jwtService.GenerateToken(user.Name);
            var expiration = DateTime.UtcNow.AddMinutes(30);  

            return new LoginResponse
            {
                Token = token,
                Expiration = expiration
            };
        }
    }
}
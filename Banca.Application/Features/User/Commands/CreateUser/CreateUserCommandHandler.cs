using MediatR;
using Banca.Core.Interfaces;
using Banca.Domain.Common;
using Banca.Domain.Entities;
using Banca.Application.Services;
using Banca.Application.Features.User.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result>
{
    private readonly IUserRepository _userRepository;

    public CreateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var encryptedPassword = AesEncryption.Encrypt(request.UserRequest.Password);
        var hmac = HmacHelper.ComputeHmac(request.UserRequest.Password);

        var user = new User
        {
            Name = request.UserRequest.Name,
            Email = request.UserRequest.Email,
            Phone = request.UserRequest.Phone,
            Address = request.UserRequest.Address,
            BirthDate = request.UserRequest.BirthDate,
            EncryptedPassword = encryptedPassword,
            Hmac = hmac,
            IsActive = true
        };

        return await _userRepository.CreateAsync(user);

    }
}
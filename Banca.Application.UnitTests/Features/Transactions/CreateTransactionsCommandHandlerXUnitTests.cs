
using Banca.Application.Features.Accounts.Commands.CreateAccounts;
using Banca.Application.UnitTests.Mocks;
using Banca.Domain.Entities;
using Banca.Domain.Interfaces;
using Moq;
using Shouldly;
using Xunit;

namespace Banca.Application.UnitTests.Features.Transactions
{
    public class CreateAccountCommandHandlerXUnitTests
    {
        private readonly Mock<IAccountRepository> _accountRepositoryMock;

        public CreateAccountCommandHandlerXUnitTests()
        {
            _accountRepositoryMock = MockAccountRepository.GetAccountRepository();
        }

        [Fact]
        public async Task CreateAccount_ShouldReturnSuccess_WhenAccountDoesNotExist()
        {
            var handler = new CreateAccountCommandHandler(_accountRepositoryMock.Object);

            var command = new CreateAccountCommand
            {
                UserId = 1,
                AccountNumber = "123456789",
                AccountBalance = 0.00m,
                AccountTypeId = 1
            };

            var result = await handler.Handle(command, CancellationToken.None);

            result.IsSuccess.ShouldBeTrue();
            _accountRepositoryMock.Verify(r => r.GetByAccountNumberAsync(command.AccountNumber), Times.Once);
            _accountRepositoryMock.Verify(r => r.CreateAsync(It.IsAny<Account>()), Times.Once);
        }

        [Fact]
        public async Task CreateAccount_ShouldReturnFailure_WhenAccountAlreadyExists()
        {
            var existingAccount = new Account
            {
                UserId = 1,
                AccountNumber = "1234514789",
                AccountBalance = 0.00m,
                AccountTypeId = 1
            };

            _accountRepositoryMock.Setup(r => r.GetByAccountNumberAsync(It.IsAny<string>()))
                .ReturnsAsync(existingAccount);

            var handler = new CreateAccountCommandHandler(_accountRepositoryMock.Object);

            var command = new CreateAccountCommand
            {
                UserId = 1,
                AccountNumber = "1234514789",
                AccountBalance = 0.00m,
                AccountTypeId = 1
            };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsSuccess.ShouldBeFalse();
            result.Error.ShouldBe("La cuenta ya existe.");
            _accountRepositoryMock.Verify(r => r.GetByAccountNumberAsync(command.AccountNumber), Times.Once);
            _accountRepositoryMock.Verify(r => r.CreateAsync(It.IsAny<Account>()), Times.Never);
        }
    }
}


using Banca.Domain.Common;
using Banca.Domain.Entities;
using Banca.Domain.Interfaces;
using Moq;

namespace Banca.Application.UnitTests.Mocks
{
    public static class MockAccountRepository
    {
        public static Mock<IAccountRepository> GetAccountRepository()
        {
            var mockRepo = new Mock<IAccountRepository>();

            mockRepo.Setup(r => r.GetByAccountNumberAsync(It.IsAny<string>()))
                .ReturnsAsync((string accountNumber) =>
                {
                    return null;
                });

            mockRepo.Setup(r => r.CreateAsync(It.IsAny<Account>()))
                .ReturnsAsync((Account account) => Result.Success());

            return mockRepo;
        }
    }
}

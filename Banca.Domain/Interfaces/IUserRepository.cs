using Banca.Domain.Common;
using Banca.Domain.Entities;

namespace Banca.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByUsernameAsync(string userName);
        Task<Result> CreateAsync(User user);
    }
}
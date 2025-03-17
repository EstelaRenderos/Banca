using Banca.Domain.Common;
using Banca.Domain.Entities;

namespace Banca.Domain.Interfaces
{
    public interface ITransferRepository
    {
        Task<Transfer> GetByIdAsync(int id);
        Task<List<Transfer>> GetAllAsync(int UserId);
        Task<Result> CreateAsync(Transfer Transfer);
        Task<Result> UpdateAsync(Transfer Transfer);
        Task<Result> DeleteAsync(int TransferId);
    }
}

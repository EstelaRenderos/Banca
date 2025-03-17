
using Banca.Domain.Entities;

namespace Banca.Domain.Interfaces
{
    public interface ITransferTypeRepository
    {
        Task<int> GetTransferTypeIdByCodeAsync(string TransferTypeCode);
        Task<TransferType> GetTransferTypeByIdAsync(int TransferTypeById);
    }
}

using Banca.Domain.Entities;
using Banca.Domain.Interfaces;
using Banca.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Banca.Infrastructure.Repository
{
    public class TransferTypeRepository : ITransferTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public TransferTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> GetTransferTypeIdByCodeAsync(string TransferTypeCode)
        {
            var transfertype = await _context.TransferTypes
                                            .FirstOrDefaultAsync(a => a.TransferTypeCode == TransferTypeCode);
            return transfertype.Id;
        }

        public async Task<TransferType> GetTransferTypeByIdAsync(int TransferTypeId)
        {
           return await _context.TransferTypes
                                            .FirstOrDefaultAsync(a => a.Id == TransferTypeId);

        }
    }
}

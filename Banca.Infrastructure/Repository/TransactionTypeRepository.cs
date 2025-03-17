using Banca.Domain.Entities;
using Banca.Domain.Interfaces;
using Banca.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Banca.Infrastructure.Repository
{
    public class TransactionTypeRepository : ITransactionTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public TransactionTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TransactionType> GetTransactionTypeByIdAsync(int id)
        {
             return await _context.TransactionTypes.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<TransactionType> GetTransactionTypeIdByCodeAsync(string TransactionTypeCode)
        {
            return await _context.TransactionTypes.FirstOrDefaultAsync(a => a.TransactionTypeCode == TransactionTypeCode);
        }
    }
}

using Banca.Domain.Common;
using Banca.Domain.Entities;
using Banca.Domain.Interfaces;
using Banca.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Banca.Infrastructure.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationDbContext _context;

        public TransactionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Transaction> GetTransactionByIdAsync(int id)
        {
            return await _context.Transactions
                                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<Transaction>> GetAllAsync(int userId)
        {
            var userList = await _context.Accounts
                .Where(a => a.UserId == userId)
                .ToListAsync();

            List<Transaction> listsTransaction = new List<Transaction>();

            foreach (var user in userList)
            {
                var transactions = await _context.Transactions
                    .Where(a => a.AccountId == user.Id)
                    .ToListAsync();

                listsTransaction.AddRange(transactions);
            }

            return listsTransaction;
        }

        public async Task<Result> CreateAsync(Transaction Transaction)
        {
            try
            {
                await _context.Transactions.AddAsync(Transaction);
                await _context.SaveChangesAsync();
                return Result.Success("Transacción realiza exitososamente");
            }
            catch (Exception ex)
            {
                return Result.Failure("Ocurrio un Error:" + ex.Message);
            }
        }
        public async Task<Result> UpdateAsync(Transaction Transaction)
        {
            try
            {

                _context.Transactions.Update(Transaction);
                await _context.SaveChangesAsync();
                return Result.Success("La transaccion fue actualizada exitosamente");
            }
            catch (Exception ex)
            {
                return Result.Failure("Ocurrio un Error:" + ex.Message);
            }
        }

        public async Task<Result> DeleteAsync(int TransactionId)
        {
            try
            {
                var Transaction = await _context.Transactions.FindAsync(TransactionId);
                if (Transaction == null)
                {
                    return Result.Failure("La transaction no fue encontrada.");
                }

                _context.Transactions.Remove(Transaction);
                await _context.SaveChangesAsync();
                return Result.Success("Se elimino correctamente la transaction");
            }
            catch (Exception ex)
            {
                return Result.Failure("Ocurrio un Error:" + ex.Message);
            }
        }

    }
}
using Banca.Domain.Common;
using Banca.Domain.Entities;
using Banca.Domain.Interfaces;
using Banca.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Banca.Infrastructure.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _context;

        public AccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Account> GetByIdAsync(int id)
        {
            return await _context.Accounts
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Account>> GetAllAsync(int UserId)
        {
            return await _context.Accounts
                        .Where(a => a.UserId == UserId)
                        .ToListAsync();
        }
        public async Task<Account> GetByAccountNumberAsync(string accountNumber)
        {
            return await _context.Accounts
                .FirstOrDefaultAsync(a => a.AccountNumber == accountNumber);
        }

        public async Task<Result> CreateAsync(Account account)
        {
            try
            {
                await _context.Accounts.AddAsync(account);
                await _context.SaveChangesAsync();
                return Result.Success("La cuenta fue creada exitosamente"); 
            }
            catch (Exception ex)
            {
                return Result.Failure("Ocurrio un Error:"+ex.Message);
            }
        }
        public async Task<Result> UpdateAsync(Account account)
        {
            try
            {
                var existingAccount = await _context.Accounts.FindAsync(account.Id);
                if (existingAccount == null)
                {
                    return Result.Failure("La cuenta no fue encontrada.");
                }

                //var userExists = await _context.Users.AnyAsync(u => u.Id == account.UserId);
                //if (!userExists)
                //{
                //    return Result.Failure("El UserId proporcionado no existe en la tabla de usuarios.");
                //}

                existingAccount.AccountBalance = account.AccountBalance;
                existingAccount.LastModifiedDate = DateTime.Now;

                _context.Accounts.Update(existingAccount);
                await _context.SaveChangesAsync();

                return Result.Success("La cuenta fue actualizada exitosamente.");
            }
            catch (Exception ex)
            {
                return Result.Failure("Ocurrió un error: " + ex.Message);
            }
        }

        public async Task<Result> DeleteAsync(int accountId)
        {
            try
            {
                var account = await _context.Accounts.FindAsync(accountId);
                if (account == null)
                {
                    return Result.Failure("La cuenta no fue encontrada.");
                }

                _context.Accounts.Remove(account);
                await _context.SaveChangesAsync();
                return Result.Success("Se elimino correctamente la cuenta");
            }
            catch (Exception ex)
            {
                return Result.Failure("Ocurrio un Error:" + ex.Message);
            }
        }
    }
}
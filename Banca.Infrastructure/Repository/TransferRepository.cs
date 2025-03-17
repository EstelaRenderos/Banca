using Banca.Domain.Common;
using Banca.Domain.Entities;
using Banca.Domain.Interfaces;
using Banca.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class TransferRepository : ITransferRepository
{
        private readonly ApplicationDbContext _context;

        public TransferRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Transfer> GetByIdAsync(int id)
        {
            return await _context.Transfers
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<Transfer>> GetAllAsync(int UserId)
        {
            return await _context.Transfers
                .Where(a => a.UserId == UserId)
                .ToListAsync();
        }

        public async Task<Result> CreateAsync(Transfer Transfer)
        {
            try
            {
                await _context.Transfers.AddAsync(Transfer);
                await _context.SaveChangesAsync();
                return Result.Success("La Transferencia fue creada exitosamente");
            }
            catch (Exception ex)
            {
                return Result.Failure("Ocurrio un Error:" + ex.Message);
            }
        }
        public async Task<Result> UpdateAsync(Transfer Transfer)
        {
            try
            {
                var existingTransfer = await _context.Transfers.FindAsync(Transfer.Id);
                if (existingTransfer == null)
                {
                    return Result.Failure("La Transferencia no fue encontrada.");
                }

                existingTransfer.Amount = Transfer.Amount;
                existingTransfer.SourceAccountId = Transfer.SourceAccountId;
                existingTransfer.DestinationAccountId = Transfer.DestinationAccountId;
                existingTransfer.DateApplication = Transfer.DateApplication;

                _context.Transfers.Update(existingTransfer);
                await _context.SaveChangesAsync();
                return Result.Success("La Transferencia fue actualizada exitosamente");
            }
            catch (Exception ex)
            {
                return Result.Failure("Ocurrio un Error:" + ex.Message);
            }
        }

        public async Task<Result> DeleteAsync(int TransferId)
        {
            try
            {
                var Transfer = await _context.Transfers.FindAsync(TransferId);
                if (Transfer == null)
                {
                    return Result.Failure("La Transferencia no fue encontrada.");
                }

                _context.Transfers.Remove(Transfer);
                await _context.SaveChangesAsync();
                return Result.Success("Se elimino correctamente la Transferencia");
            }
            catch (Exception ex)
            {
                return Result.Failure("Ocurrio un Error:" + ex.Message);
            }
        }
    }
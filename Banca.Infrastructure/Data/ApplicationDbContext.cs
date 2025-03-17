
using Microsoft.EntityFrameworkCore;
using Banca.Domain.Entities;

namespace Banca.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<Transfer> Transfers { get; set; }
        public DbSet<TransferType> TransferTypes { get; set; }
    }
}

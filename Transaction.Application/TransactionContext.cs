using TransactionCore.Entities;
using Microsoft.EntityFrameworkCore;
namespace TransactionApplication
{
    public class TransactionContext : DbContext
    {
        public TransactionContext(DbContextOptions<TransactionContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
                // Para que no interprete los enum como INT, evaluar si esto es practico. 
            modelBuilder.Entity<Transaction>()
                .Property(p => p.Type)
                .HasConversion<string>(); // Convert to/from string for database storage
            modelBuilder.Entity<Transaction>()
                .Property(p => p.Status)
                .HasConversion<string>(); // Convert to/from string for database storage
        }

        public DbSet<Transaction> Transactions { get; set; }
    }
}

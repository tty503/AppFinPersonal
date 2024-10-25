using AccountCore.Entities;
using Microsoft.EntityFrameworkCore;
namespace AccountApplication
{
    public class AccountContext : DbContext
    {
        public AccountContext(DbContextOptions<AccountContext> options) : base(options) 
        { 
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Account>().HasKey(x => new {x.Owners});
        }

        public DbSet<Account> Accounts { get; set; }
    }
}

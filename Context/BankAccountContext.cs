using Microsoft.EntityFrameworkCore;
using UniversityTuitionPayment.Model;

namespace UniversityTuitionPayment.Context
{
    public class BankAccountContext : DbContext
    {
        public BankAccountContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<BankAccount> BankAccounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankAccount>()
                .HasKey(u => u.Id);
        }
    }
}

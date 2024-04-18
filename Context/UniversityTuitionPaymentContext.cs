using Microsoft.EntityFrameworkCore;
using UniversityTuitionPayment.Model;

namespace UniversityTuitionPayment.Context
{
    public class UniversityTuitionPaymentContext : DbContext
    {
        public UniversityTuitionPaymentContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Term> Terms { get; set; }
        public DbSet<Tuition> Tuitions { get; set; }
        public DbSet<University> Universities { get; set; }

    }
}

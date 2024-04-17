using Microsoft.EntityFrameworkCore;
using UniversityTuitionPayment.Model;

namespace UniversityTuitionPayment.Context
{
    public class TermContext : DbContext
    {
        public TermContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Term> Terms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Term>()
                .HasKey(u => u.Id);
        }
    }
}

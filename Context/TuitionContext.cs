using Microsoft.EntityFrameworkCore;
using UniversityTuitionPayment.Model;

namespace UniversityTuitionPayment.Context
{
    public class TuitionContext : DbContext
    {
        public TuitionContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Tuition> Tuitions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tuition>()
                .HasKey(u => u.Id);
        }
    }
}

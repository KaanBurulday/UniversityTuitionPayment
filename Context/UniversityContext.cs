using Microsoft.EntityFrameworkCore;
using UniversityTuitionPayment.Model;

namespace UniversityTuitionPayment.Context
{
    public class UniversityContext : DbContext
    {
        public UniversityContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<University> Universities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<University>()
                .HasKey(u => u.Id);
        }
    }
}

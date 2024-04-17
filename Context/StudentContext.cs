using Microsoft.EntityFrameworkCore;
using UniversityTuitionPayment.Model;

namespace UniversityTuitionPayment.Context
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasKey(u => u.Id);
        }
    }
}

using EF_CoreAsync.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_CoreAsync.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                // Unique Email Constraint
                entity.HasIndex(u => u.Email).IsUnique();

                // Required + Max Length
                entity.Property(u => u.Name)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(u => u.Email)
                      .IsRequired()
                      .HasMaxLength(150);
            });
        }
    } // ← class closing
}     // ← namespace closing
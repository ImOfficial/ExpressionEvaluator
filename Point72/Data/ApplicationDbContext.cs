using Microsoft.EntityFrameworkCore;
using Point72.Models;

namespace Point72.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        public DbSet<Expressions> Expressions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Expressions>(entity =>
            {
                entity.ToTable("Expressions");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Expression).IsRequired();
                entity.Property(e => e.Result).IsRequired();
                entity.Property(e => e.CreatedAt).IsRequired().HasDefaultValueSql("GETUTCDATE()");
                entity.HasIndex(e=>e.Result);
            });
        }

    } 

}


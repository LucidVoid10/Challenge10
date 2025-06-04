using Microsoft.EntityFrameworkCore;
using MingCompany.Domain.Entities;

namespace MingCompany.Infrastructure.Data
{
    public class MiningDbContext : DbContext
    {
        public MiningDbContext(DbContextOptions<MiningDbContext> options) : base(options) { }

        public DbSet<Operation> Operations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Operation>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Type).HasConversion<int>();
                entity.Property(e => e.Date).IsRequired();
                entity.Property(e => e.Status).IsRequired();
                entity.Property(e => e.CompletedDate).IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
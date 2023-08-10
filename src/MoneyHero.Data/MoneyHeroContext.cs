using Microsoft.EntityFrameworkCore;
using MoneyHero.Domain.Models;

namespace MoneyHero.Data
{
    public class MoneyHeroContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public MoneyHeroContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(a =>
            {
                a.HasKey(x => x.Id);
                a.Property(x => x.Name).HasMaxLength(100).IsRequired();
                a.Property(x => x.Description).HasMaxLength(200).IsRequired(false);
                a.Property(x => x.InitialBalance).HasPrecision(18, 2).IsRequired().HasDefaultValue(0);
                a.HasMany(x => x.Operations).WithOne(x => x.Account);
            });

            modelBuilder.Entity<Operation>(o =>
            {
                o.HasKey(x => x.Id);
                o.Property(x => x.Amount).HasPrecision(18, 2).IsRequired();
                o.Property(x => x.ParentId).IsRequired(false);
                o.HasOne(o => o.Account).WithMany(o => o.Operations).HasForeignKey(o => o.AccountId);
                o.HasOne(x => x.Parent).WithOne();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}

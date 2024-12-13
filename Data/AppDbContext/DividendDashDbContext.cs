using Data.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.AppDbContext
{
    public class DividendDashDbContext: DbContext
    {
        public DbSet<Holding> Holdings { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Summary> Summaries { get; set; }

        public DividendDashDbContext(DbContextOptions<DividendDashDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           
            modelBuilder.Entity<Summary>()
                .Property(s => s.Dividend)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Summary>()
                .Property(s => s.DividendCharges)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Summary>()
                .Property(s => s.DividendTotal)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Summary>()
                .Property(s => s.TotalCharges)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Summary>()
                .Property(s => s.Gross)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Summary>()
                .Property(s => s.Net)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Summary>()
                .Property(s => s.Profit)
                .HasColumnType("decimal(18, 2)");
            /****************************************/
            modelBuilder.Entity<Transaction>()
                .Property(t => t.Closing)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Transaction>()
                .Property(t => t.ClosingCharges)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Transaction>()
                .Property(t => t.ClosingTotal)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Transaction>()
                .Property(t => t.OpeningTotal)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Transaction>()
                .Property(t => t.Opening)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Transaction>()
                .Property(t => t.OpeningCharges)
                .HasColumnType("decimal(18, 2)");

            /****************************************/
            modelBuilder.Entity<Holding>()
                .HasOne(h => h.Transaction)
                .WithOne(t => t.Holding)
                .HasForeignKey<Transaction>(c => c.HoldingId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Holding>()
                .HasOne(h => h.Summary)
                .WithOne(s => s.Holding)
                .HasForeignKey<Summary>(c => c.HoldingId)
                .OnDelete(DeleteBehavior.Cascade);
            
            /****************************/

            modelBuilder.Entity<Summary>()
                .Property(s => s.HoldingId)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Transaction>()
                .Property(t => t.HoldingId)
                .HasDefaultValueSql("NEWID()");

        }
    }
}

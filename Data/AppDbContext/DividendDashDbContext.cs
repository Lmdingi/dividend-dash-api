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
    }
}

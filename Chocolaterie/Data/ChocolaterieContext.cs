using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Chocolaterie.Models;
using System.Reflection.Metadata;
using Microsoft.Extensions.Hosting;

namespace Chocolaterie.Data
{
    public class ChocolaterieContext : DbContext
    {
        public ChocolaterieContext (DbContextOptions<ChocolaterieContext> options)
            : base(options)
        {
        }

        public DbSet<Factory> Factories { get; set; } = default!;

        public DbSet<ChocolateBar>? ChocolateBars { get; set; }
        public DbSet<ChocolateBar>? Stocks { get; set; }
        public DbSet<ChocolateBar>? WholeSalers { get; set; }
        public DbSet<ChocolateBar>? OrderLines { get; set; }
        public DbSet<ChocolateBar>? Orders { get; set; }
        public DbSet<ChocolateBar>? Clients { get; set; }
        public DbSet<ChocolateBar>? Discounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderLine>()
            .HasOne(o => o.Stock)
            .WithMany(s => s.OrderLines)
            .HasForeignKey(o => o.StockId)
            .OnDelete(DeleteBehavior.ClientNoAction);
        }
    }
}

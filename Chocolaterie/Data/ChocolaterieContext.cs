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

        public DbSet<Factory> Factory { get; set; } = default!;

        public DbSet<ChocolateBar>? ChocolateBar { get; set; }
        public DbSet<ChocolateBar>? Stock { get; set; }
        public DbSet<ChocolateBar>? WholeSaler { get; set; }
        public DbSet<ChocolateBar>? OrderLine { get; set; }
        public DbSet<ChocolateBar>? Order { get; set; }
        public DbSet<ChocolateBar>? Client { get; set; }
        public DbSet<ChocolateBar>? Discount { get; set; }

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

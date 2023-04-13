using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Chocolaterie.Entities;
using System.Reflection.Metadata;
using Microsoft.Extensions.Hosting;
using Chocolaterie.Extensions;
using Chocolaterie.Maps;
using System.Collections;

namespace Chocolaterie.Data
{
    public class ChocolaterieContext : DbContext
    {
        public ChocolaterieContext (DbContextOptions<ChocolaterieContext> options)
            : base(options)
        {
        }


        public DbSet<ChocolateBar>? ChocolateBars { get; set; }
        public DbSet<Client>? Clients { get; set; }
        public DbSet<Discount>? Discounts { get; set; }
        public DbSet<Factory> Factories { get; set; } = default!;
        public DbSet<Order>? Orders { get; set; }
        public DbSet<OrderLine>? OrderLines { get; set; }
        public DbSet<Stock>? Stocks { get; set; }
        public DbSet<WholeSaler>? WholeSalers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderLine>()
            .HasOne(o => o.Stock)
            .WithMany(s => s.OrderLines)
            .HasForeignKey(o => o.StockId)
            .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.ApplyConfiguration(new ChocolateBarMap());
            modelBuilder.ApplyConfiguration(new ClientMap());
            modelBuilder.ApplyConfiguration(new DiscountMap());
            modelBuilder.ApplyConfiguration(new FactoryMap());
            modelBuilder.ApplyConfiguration(new OrderMap());
            modelBuilder.ApplyConfiguration(new OrderLineMap());
            modelBuilder.ApplyConfiguration(new StockMap());
            modelBuilder.ApplyConfiguration(new WholeSalerMap());

            modelBuilder.Seed();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ChangeTracker.SetAuditProperties();
            return await base.SaveChangesAsync(cancellationToken);
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            ChangeTracker.SetAuditProperties();
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override int SaveChanges()
        {
            ChangeTracker.SetAuditProperties();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            ChangeTracker.SetAuditProperties();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

    }
}

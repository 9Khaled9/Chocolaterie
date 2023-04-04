using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Chocolaterie.Models;

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
    }
}

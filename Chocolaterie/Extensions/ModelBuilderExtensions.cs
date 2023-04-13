using Chocolaterie.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chocolaterie.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Factory>().HasData(
                new Factory { Id = 1, Name = "Neuhaus", Address = "", Email = "", Contact = "" },
                new Factory { Id = 2, Name = "Ghandour", Address = "", Email = "", Contact = "" },
                new Factory { Id = 3, Name = "Torku", Address = "", Email = "", Contact = "" }
            );

            modelBuilder.Entity<ChocolateBar>().HasData(
                new ChocolateBar { Id = 1, FactoryId = 1, Name = "SPRING BALLOTIN 1/4 LB 10 PCS", Description = "SPRING BALLOTIN 1/4 LB 10 PCS", Price = 24.90 },
                new ChocolateBar { Id = 2, FactoryId = 1, Name = "CLASSIC BALLOTIN 0.25 LB", Description = "CLASSIC BALLOTIN 0.25 LB", Price = 24.90 },
                new ChocolateBar { Id = 3, FactoryId = 1, Name = "LOVE BALLOTIN 1 LB", Description = "LOVE BALLOTIN 1 LB", Price = 78.90 },

                new ChocolateBar { Id = 4, FactoryId = 2, Name = "Digestive", Description = "Gandour Digestive Chocolate Biscuits are sprinkled with chocolate chips, which is also its most prominent distinguishing ingredient.", Price = 18.5 },
                new ChocolateBar { Id = 5, FactoryId = 2, Name = "Unica", Description = "Creamy Hazelnut", Price = 10.5 },
                new ChocolateBar { Id = 6, FactoryId = 2, Name = "Pik-One", Description = "Chewy Caramel", Price = 10.5 },

                new ChocolateBar { Id = 7, FactoryId = 3, Name = "Bitter Cikolata", Description = "Torku Classic Chocolate Series (Dark Chocolate (60% Cacao )", Price = 56 },
                new ChocolateBar { Id = 8, FactoryId = 3, Name = "Gold", Description = "White Chocolate With Cocoa Hazelnut Cream Filling", Price = 28.5 },
                new ChocolateBar { Id = 9, FactoryId = 3, Name = "Çokofest", Description = "Torku Çokofest Caramel Filled Milk Chocolate 60 gr", Price = 55.90 }
            );

            modelBuilder.Entity<Client>().HasData(
                new Client { Id = 1, Name = "Hoz Market", Description = "Hoz Market", Address = "", Email = "", Contact = "" },
                new Client { Id = 2, Name = "spinneys", Description = "spinneys", Address = "", Email = "", Contact = "" },
                new Client { Id = 3, Name = "mcdonald's", Description = "mcdonald's", Address = "", Email = "", Contact = "" }
            );

            modelBuilder.Entity<Discount>().HasData(
                new Discount { Id = 1, Title = "discount 0%", Description = "No discount is applied", Percentage = 0, AboveConstraint = 0},
                new Discount { Id = 2, Title = "discount 10%", Description = "A 10% discount is applied above 10 chocolate bars", Percentage = 10, AboveConstraint = 10},
                new Discount { Id = 3, Title = "discount 20%", Description = "A 20% discount is applied above 20 chocolate bars", Percentage = 20, AboveConstraint = 20 }
            );

            modelBuilder.Entity<WholeSaler>().HasData(
                new WholeSaler { Id = 1, Name = "SEA", Description = "SOUTH EXPORT ALLIANCE - Produits alimentaires et non alimentaires asiatiques authentiques", Address = "RUE DE LA PRINCESSE, 7100 TRIVIÈRES, BELGIUM", Email = "info@sealliance.be", Contact = "+32 472 08 77 16" },
                new WholeSaler { Id = 2, Name = "MEGAFORM", Description = "MEGAFORM - Innovative and educational products for physical education distributors", Address = "MEGAFORM AG - Rue Haute, 177 - 4700 EUPEN Belgium", Email = "info@megaform.com", Contact = "+32 87 32 17 18" },
                new WholeSaler { Id = 3, Name = "AFRIMEX BELGIUM", Description = "AFRIMEX BELGIUM - For those who choose quality", Address = "Kwikaard 104 - 2980 Zoersel - Belgium", Email = "info@afrimex.be", Contact = "+32 (0)3 385 58 28" }
            );

            modelBuilder.Entity<Stock>().HasData(
                new Stock { Id = 1, ChocolateBarId = 1, WholeSalerId = 1, Quatity = 50, Description = "" },
                new Stock { Id = 2, ChocolateBarId = 2, WholeSalerId = 1, Quatity = 50, Description = "" },
                new Stock { Id = 3, ChocolateBarId = 3, WholeSalerId = 1, Quatity = 50, Description = "" },
                new Stock { Id = 4, ChocolateBarId = 4, WholeSalerId = 1, Quatity = 50, Description = "" },
                new Stock { Id = 5, ChocolateBarId = 5, WholeSalerId = 1, Quatity = 50, Description = "" },
                new Stock { Id = 6, ChocolateBarId = 6, WholeSalerId = 1, Quatity = 50, Description = "" },
                new Stock { Id = 7, ChocolateBarId = 7, WholeSalerId = 1, Quatity = 50, Description = "" },
                new Stock { Id = 8, ChocolateBarId = 8, WholeSalerId = 1, Quatity = 50, Description = "" },
                new Stock { Id = 9, ChocolateBarId = 9, WholeSalerId = 1, Quatity = 50, Description = "" },

                new Stock { Id = 10, ChocolateBarId = 1, WholeSalerId = 2, Quatity = 50, Description = "" },
                new Stock { Id = 11, ChocolateBarId = 2, WholeSalerId = 2, Quatity = 50, Description = "" },
                new Stock { Id = 12, ChocolateBarId = 3, WholeSalerId = 2, Quatity = 50, Description = "" },
                new Stock { Id = 13, ChocolateBarId = 4, WholeSalerId = 2, Quatity = 50, Description = "" },
                new Stock { Id = 14, ChocolateBarId = 5, WholeSalerId = 2, Quatity = 50, Description = "" },
                new Stock { Id = 15, ChocolateBarId = 6, WholeSalerId = 2, Quatity = 50, Description = "" },

                new Stock { Id = 16, ChocolateBarId = 7, WholeSalerId = 3, Quatity = 50, Description = "" },
                new Stock { Id = 17, ChocolateBarId = 8, WholeSalerId = 3, Quatity = 50, Description = "" },
                new Stock { Id = 18, ChocolateBarId = 9, WholeSalerId = 3, Quatity = 50, Description = "" }
            );
        }
    }
}

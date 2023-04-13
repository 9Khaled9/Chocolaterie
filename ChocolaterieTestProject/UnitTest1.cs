using AutoMapper;
using Chocolaterie.Controllers;
using Chocolaterie.Data;
using Chocolaterie.DTOs;
using Chocolaterie.Entities;
using Chocolaterie.Services;
using Moq;

namespace ChocolaterieTestProject
{
    public class ChocolaterieServiceTests
    {
        private readonly Mock<IChocolaterieService> chocolaterieService;
        public ChocolaterieServiceTests()
        {
            chocolaterieService = new Mock<IChocolaterieService>();
        }

        [Fact]
        public void ListChocolateBarsByFactory_Chocolaterie()
        {
            //arrange
            var chocolateBarsFactoryOneList = GetChocolateBarsData().Where(x => x.FactoryId == 1).ToList();
            chocolaterieService.Setup(x => x.ListChocolateBarsByFactoryAsync(1).Result)
                .Returns(chocolateBarsFactoryOneList
                .Where(x => x.FactoryId == 1).ToList());
            var chocolaterieController = new ChocolaterieController(chocolaterieService.Object);

            //act
            var chocolateBarsResult = chocolaterieController.ListChocolateBarsByFactoryAsync(1).Result;

            //assert
            Assert.NotNull(chocolateBarsResult);
            Assert.Equal(chocolateBarsFactoryOneList.Count, chocolateBarsResult.Count);
            Assert.True(chocolateBarsFactoryOneList.Count == chocolateBarsResult.Count);
        }

        private List<ChocolateBarDto> GetChocolateBarsData()
        {
            List<ChocolateBarDto> chocolateBarsData = new List<ChocolateBarDto>
        {
            new ChocolateBarDto { Id = 1, FactoryId = 1, Name = "SPRING BALLOTIN 1/4 LB 10 PCS", Description = "SPRING BALLOTIN 1/4 LB 10 PCS", Price = 24.90 },
            new ChocolateBarDto { Id = 2, FactoryId = 1, Name = "CLASSIC BALLOTIN 0.25 LB", Description = "CLASSIC BALLOTIN 0.25 LB", Price = 24.90 },
            new ChocolateBarDto { Id = 3, FactoryId = 1, Name = "LOVE BALLOTIN 1 LB", Description = "LOVE BALLOTIN 1 LB", Price = 78.90 },

            new ChocolateBarDto { Id = 4, FactoryId = 2, Name = "Digestive", Description = "Gandour Digestive Chocolate Biscuits are sprinkled with chocolate chips, which is also its most prominent distinguishing ingredient.", Price = 18.5 },
            new ChocolateBarDto { Id = 5, FactoryId = 2, Name = "Unica", Description = "Creamy Hazelnut", Price = 10.5 },
            new ChocolateBarDto { Id = 6, FactoryId = 2, Name = "Pik-One", Description = "Chewy Caramel", Price = 10.5 },

            new ChocolateBarDto { Id = 7, FactoryId = 3, Name = "Bitter Cikolata", Description = "Torku Classic Chocolate Series (Dark Chocolate (60% Cacao )", Price = 56 },
            new ChocolateBarDto { Id = 8, FactoryId = 3, Name = "Gold", Description = "White Chocolate With Cocoa Hazelnut Cream Filling", Price = 28.5 },
            new ChocolateBarDto { Id = 9, FactoryId = 3, Name = "Çokofest", Description = "Torku Çokofest Caramel Filled Milk Chocolate 60 gr", Price = 55.90 }
        };
            return chocolateBarsData;
        }
    }
}
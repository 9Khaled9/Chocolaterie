using Chocolaterie.DTOs.Base;

namespace Chocolaterie.DTOs
{
    public class ChocolateBarDto : BaseDto
    {
        public ChocolateBarDto(string name, double price, int factoryId)
        {
            Name = name;
            Price = price;
            FactoryId = factoryId;
        }

        public string Name { get; set; }

        public string? Description { get; set; }

        public double Price { get; set; }

        public int FactoryId { get; set; }
    }
}

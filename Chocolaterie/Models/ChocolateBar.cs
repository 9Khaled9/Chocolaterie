using Chocolaterie.Models.Common;

namespace Chocolaterie.Models
{
    public class ChocolateBar : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public Factory Factory { get; set; }
    }
}

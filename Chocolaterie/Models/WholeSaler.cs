using Chocolaterie.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace Chocolaterie.Models
{
    public class WholeSaler : BaseEntity
    {
        public WholeSaler()
        {
        }

        public WholeSaler(string name)
        {
            Name = name;
        }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public ICollection<Stock> Stocks { get; } = new List<Stock>();

        public ICollection<Order> Orders { get; } = new List<Order>();
    }
}
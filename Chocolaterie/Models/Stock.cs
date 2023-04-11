using Chocolaterie.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace Chocolaterie.Models
{
    public class Stock : BaseEntity
    {
        public Stock()
        {
        }

        public Stock(int quantity)
        {
            Quatity = quantity;
        }

        [Required]
        public int Quatity { get; set; }

        public string Description { get; set; }

        public int ChocolateBarId { get; set; }
        public ChocolateBar ChocolateBar { get; set; }

        public int WholeSalerId { get; set; }
        public WholeSaler WholeSaler { get; set; }

        public ICollection<OrderLine> OrderLines { get; } = new List<OrderLine>();

    }
}

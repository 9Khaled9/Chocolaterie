using Chocolaterie.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Chocolaterie.Entities
{
    public class Stock : EntityBase
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

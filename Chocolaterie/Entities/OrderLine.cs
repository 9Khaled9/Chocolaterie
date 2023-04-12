using Chocolaterie.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Chocolaterie.Entities
{
    public class OrderLine : EntityBase
    {
        public OrderLine()
        {
        }

        public OrderLine(int quantity)
        {
            Quantity = quantity;
        }

        [Required]
        public int Quantity { get; set; }

        public int StockId { get; set; }
        public Stock Stock { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

    }
}
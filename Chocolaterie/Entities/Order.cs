using Chocolaterie.Entities.Base;
using Chocolaterie.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace Chocolaterie.Entities
{
    public class Order : EntityBase
    {
        public Order()
        {
        }

        public Order(OrderType orderType)
        {
            OrderType = orderType;
        }

        [Required]
        public OrderType OrderType { get; set; }

        public string Description { get; set; }

        public double Total { get; set; }

        public double DiscountAmount { get; set; }

        public double TotalAfterDiscount { get; set; }

        public int WholeSalerId { get; set; }
        public WholeSaler WholeSaler { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int DiscountId { get; set; }
        public Discount? Discount { get; set; }

        public ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();

        public void AddLine (OrderLine line)
        {
            OrderLines.Add(line);
        }
    }
}
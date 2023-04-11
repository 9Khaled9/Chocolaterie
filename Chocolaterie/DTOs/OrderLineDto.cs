using Chocolaterie.DTOs.Common;
using Chocolaterie.Models;

namespace Chocolaterie.DTOs
{
    public class OrderLineDto : BaseDto
    {
        public OrderLineDto(int quantity, int stockId, int orderId)
        {
            Quantity = quantity;
            StockId = stockId;
            OrderId = orderId;
        }

        public int Quantity { get; set; }

        public int StockId { get; set; }

        public int OrderId { get; set; }
    }
}

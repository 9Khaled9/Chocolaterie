using Chocolaterie.DTOs.Common;
using Chocolaterie.Models;
using Chocolaterie.Models.Common;

namespace Chocolaterie.DTOs
{
    public class OrderDto : BaseDto
    {
        public OrderDto(OrderType orderType, int wholeSalerId, int clientId, int discountId)
        {
            OrderType = orderType;
            WholeSalerId = wholeSalerId;
            ClientId = clientId;
            DiscountId = discountId;
        }

        public OrderType OrderType { get; set; }

        public string Description { get; set; }

        public int Total { get; set; }

        public int DiscountAmount { get; set; }

        public int TotalAfterDiscount { get; set; }

        public int WholeSalerId { get; set; }

        public int ClientId { get; set; }

        public int DiscountId { get; set; }
    }
}

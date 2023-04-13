using Chocolaterie.DTOs.Base;
using Chocolaterie.Entities;
using Chocolaterie.Entities.Common;

namespace Chocolaterie.DTOs
{
    public class OrderDto : BaseDto
    {
        public OrderDto(int wholeSalerId, int clientId)
        {
            WholeSalerId = wholeSalerId;
            ClientId = clientId;
        }

        //public OrderType OrderType { get; set; }

        public string Description { get; set; }

        public int Total { get; set; }

        public int DiscountAmount { get; set; }

        public int TotalAfterDiscount { get; set; }

        public int WholeSalerId { get; set; }

        public int ClientId { get; set; }

        //public int DiscountId { get; set; }

        public IList<OrderLineDto> OrderLines { get; set; }
    }
}

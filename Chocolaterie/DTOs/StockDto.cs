
using Chocolaterie.DTOs.Base;

namespace Chocolaterie.DTOs
{
    public class StockDto : BaseDto
    {
        public StockDto(int quatity, int chocolateBarId, int wholeSalerId)
        {
            Quatity = quatity;
            ChocolateBarId = chocolateBarId;
            WholeSalerId = wholeSalerId;
        }

        public int Quatity { get; set; }

        public string Description { get; set; }

        public int ChocolateBarId { get; set; }

        public int WholeSalerId { get; set; }
    }
}

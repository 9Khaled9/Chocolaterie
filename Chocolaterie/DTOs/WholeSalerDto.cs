using Chocolaterie.DTOs.Base;

namespace Chocolaterie.DTOs
{
    public class WholeSalerDto : BaseDto
    {
        public WholeSalerDto(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }
    }
}

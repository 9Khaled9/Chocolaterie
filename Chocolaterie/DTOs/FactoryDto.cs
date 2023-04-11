using Chocolaterie.DTOs.Common;

namespace Chocolaterie.DTOs
{
    public class FactoryDto : BaseDto
    {
        public FactoryDto(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}

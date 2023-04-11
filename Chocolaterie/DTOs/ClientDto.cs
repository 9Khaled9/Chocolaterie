using Chocolaterie.DTOs.Common;

namespace Chocolaterie.DTOs
{
    public class ClientDto : BaseDto
    {
        public ClientDto(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }
    }
}

using Chocolaterie.Models.Common;
using Microsoft.Build.Framework;

namespace Chocolaterie.Models
{
    public class Client : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public Client(string name)
        {
            Name = name;
        }
    }
}

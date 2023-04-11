using Chocolaterie.Models.Common;
using Microsoft.Build.Framework;

namespace Chocolaterie.Models
{
    public class Client : BaseEntity
    {
        public Client() { }

        public Client(string name)
        {
            Name = name;
        }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public ICollection<Order> Orders { get; } = new List<Order>();

    }
}

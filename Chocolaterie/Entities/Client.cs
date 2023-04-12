using Chocolaterie.Entities.Base;
using Microsoft.Build.Framework;

namespace Chocolaterie.Entities
{
    public class Client : EntityBase
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

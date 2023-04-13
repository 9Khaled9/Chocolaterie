using Chocolaterie.Entities.Base;
using Microsoft.Build.Framework;
using Microsoft.Extensions.Hosting;

namespace Chocolaterie.Entities
{
    public class Factory : EntityBase
    {
        public Factory() { }

        public Factory(string name)
        {
            Name = name;
        }

        [Required]
        public string Name { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Contact { get; set; }

        public ICollection<ChocolateBar> ChocolateBars { get; } = new List<ChocolateBar>();

    }
}

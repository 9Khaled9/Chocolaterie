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

        public ICollection<ChocolateBar> ChocolateBars { get; } = new List<ChocolateBar>();

    }
}

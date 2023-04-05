using Chocolaterie.Models.Common;
using Microsoft.Build.Framework;
using Microsoft.Extensions.Hosting;

namespace Chocolaterie.Models
{
    public class Factory : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public ICollection<ChocolateBar> ChocolateBars { get; } = new List<ChocolateBar>();

        public Factory(string name)
        {
            Name = name;
        }
    }
}

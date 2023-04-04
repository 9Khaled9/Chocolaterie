using Chocolaterie.Models.Common;
using Microsoft.Extensions.Hosting;

namespace Chocolaterie.Models
{
    public class Factory : BaseEntity
    {
        public string Name { get; set; }
        public List<ChocolateBar> ChocolateBars { get; set; }
    }
}

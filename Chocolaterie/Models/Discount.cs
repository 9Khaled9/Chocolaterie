using Chocolaterie.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace Chocolaterie.Models
{
    public class Discount : BaseEntity
    {
        public Discount()
        {
        }

        public Discount(string title, double percentage)
        {
            Title = title;
            Percentage = percentage;
        }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public double Percentage { get; set; }

        public ICollection<Order> Orders { get; } = new List<Order>();

    }
}

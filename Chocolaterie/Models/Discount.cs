using Chocolaterie.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace Chocolaterie.Models
{
    public class Discount : BaseEntity
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public double Percentage { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public Discount(string title, double percentage)
        {
            Title = title;
            Percentage = percentage;
        }
    }
}

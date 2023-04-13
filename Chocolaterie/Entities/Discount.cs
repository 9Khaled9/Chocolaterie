using Chocolaterie.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Chocolaterie.Entities
{
    public class Discount : EntityBase
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

        [Required]
        public int AboveConstraint { get; set; }

        public ICollection<Order> Orders { get; } = new List<Order>();

    }
}

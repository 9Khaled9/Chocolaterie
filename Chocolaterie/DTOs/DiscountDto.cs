using Chocolaterie.DTOs.Common;

namespace Chocolaterie.DTOs
{
    public class DiscountDto : BaseDto
    {
        public DiscountDto(string title, double percentage)
        {
            Title = title;
            Percentage = percentage;
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public double Percentage { get; set; }
    }
}

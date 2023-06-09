﻿using Chocolaterie.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chocolaterie.Entities
{
    public class ChocolateBar : EntityBase
    {
        public ChocolateBar()
        {
        }

        public ChocolateBar(string name, double price)
        {
            Name = name;
            Price = price;
        }

        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Required]
        public double Price { get; set; }

        public int FactoryId { get; set; }
        public Factory Factory { get; set; }

        public ICollection<Stock> Stocks { get; } = new List<Stock>();

    }
}

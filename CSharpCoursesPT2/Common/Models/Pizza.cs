using Common.Interfaces.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Pizza : ICountable, IDisplayableItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public double? Diameter { get; set; }

        public int? WeightGs { get; set; }

        public List<string> Ingredients { get; set; }

        public static int Counter { get; private set; } = 0;
        public Pizza(string name)
        {
            Id = ++Counter;
            Name = name;
        }

        public Pizza()
        {
        }

        public string PrintHTML()
        {
            throw new NotImplementedException();
        }
    }
}

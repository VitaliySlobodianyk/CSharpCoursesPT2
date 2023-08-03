using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Persons
{
    public class Seller : Person
    {
        public Seller(string name) : base(name)
        {
            Cars = new List<Car>();
        }

        public List<Car> Cars { get; set; }
    }
}

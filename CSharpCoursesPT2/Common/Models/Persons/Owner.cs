using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Persons
{
    public class Owner : Person
    {
        public Owner(string name) : base(name)
        {
            Cars = new List<Car>();
        }

        public List<Car> Cars { get; set; }
    }
}
